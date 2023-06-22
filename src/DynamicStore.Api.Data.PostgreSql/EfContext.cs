using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using DynamicStore.Api.Data.PostgreSql.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;

namespace DynamicStore.Api.Data.PostgreSql
{
	/// <summary>
	/// Контекст EF Core для приложения
	/// </summary>
	public class EfContext : DbContext, IDbContext
	{
		private const string DefaultSchema = "public";
		private readonly IUserContext _userContext;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IMediator _domainEventsDispatcher;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="options">Параметры подключения к БД</param>
		/// <param name="userContext">Контекст текущего пользователя</param>
		/// <param name="dateTimeProvider">Провайдер даты и времени</param>
		/// <param name="domainEventsDispatcher">Медиатор для доменных событий</param>
		public EfContext(
			DbContextOptions<EfContext> options,
			IUserContext userContext,
			IDateTimeProvider dateTimeProvider,
			IMediator domainEventsDispatcher)
			: base(options)
		{
			_userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
			_dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
			_domainEventsDispatcher = domainEventsDispatcher ?? throw new ArgumentNullException(nameof(domainEventsDispatcher));
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		#region Entities

		/// <inheritdoc/>
		public DbSet<Advertising> Advertisements { get; set; }

		/// <inheritdoc/>
		public DbSet<Category> Categories { get; set; }

		/// <inheritdoc/>
		public DbSet<File> Files { get; set; }

		/// <inheritdoc/>
		public DbSet<Layout> Layouts { get; set; }

		/// <inheritdoc/>
		public DbSet<Order> Orders { get; set; }

		/// <inheritdoc/>
		public DbSet<OrderProduct> OrderProducts { get; set; }

		/// <inheritdoc/>
		public DbSet<Product> Products { get; set; }

		/// <inheritdoc/>
		public DbSet<Shop> Shops { get; set; }

		/// <inheritdoc/>
		public DbSet<User> Users { get; set; }

		#endregion

		/// <inheritdoc/>
		public bool IsInMemory => Database.IsInMemory();

		/// <inheritdoc/>
		public void Clean()
		{
			var changedEntriesCopy = ChangeTracker.Entries()
				.Where(e => e.State is EntityState.Added or
							EntityState.Modified or
							EntityState.Deleted)
				.ToList();

			foreach (var entry in changedEntriesCopy)
				entry.State = EntityState.Detached;
		}

		/// <inheritdoc/>
		public override int SaveChanges()
#pragma warning disable VSTHRD002 // Avoid problematic synchronous waits
			=> SaveChangesAsync(true, default).GetAwaiter().GetResult();
#pragma warning restore VSTHRD002 // Avoid problematic synchronous waits

		/// <inheritdoc/>
		public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			var entityEntries = ChangeTracker.Entries().ToArray();

			// перед применением событий получаем их все из доменных сущностей во избежание дубликации в рекурсии
			var domainEvents = entityEntries
				.Select(po => po.Entity)
				.OfType<EntityBase>()
				.SelectMany(x => x.RetrieveDomainEvents())
				.ToArray();

			try
			{
				foreach (var @event in domainEvents)
					await _domainEventsDispatcher.Publish(@event, cancellationToken);

				if (entityEntries.Length > 10)
					entityEntries.AsParallel().ForAll(OnSave);
				else
					foreach (var entityEntry in entityEntries)
						OnSave(entityEntry);

				return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
			}
			catch (DbUpdateException ex)
			{
				return HandleDbUpdateException(ex, cancellationToken);
			}
		}

		/// <inheritdoc/>
		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
			await SaveChangesAsync(true, cancellationToken);

		protected virtual int HandleDbUpdateException(DbUpdateException ex, CancellationToken cancellationToken = default)
		{
			if (ex?.InnerException is PostgresException postgresEx)
				throw postgresEx.SqlState switch
				{
					PostgresErrorCodes.ForeignKeyViolation => new ApplicationExceptionBase(
						$"Заданы некорректные идентификаторы для внешних ключей сущности: {postgresEx.Detail}", ex),
					PostgresErrorCodes.UniqueViolation => new DuplicateUniqueKeyException(ex),
					_ => ex,
				};
			throw ex ?? throw new ArgumentNullException(nameof(ex));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.HasDefaultSchema(DefaultSchema);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);

			var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
				v => v.ToUniversalTime(),
				v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

			var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
				v => v.HasValue ? v.Value.ToUniversalTime() : v,
				v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				// Глобальные фильтры на soft delete
				if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
					entityType.AddSoftDeleteQueryFilter();

				if (entityType.IsKeyless)
				{
					continue;
				}

				// Перевод дат сущностей в UTC
				foreach (var property in entityType.GetProperties())
				{
					if (property.ClrType == typeof(DateTime))
					{
						property.SetValueConverter(dateTimeConverter);
					}
					else if (property.ClrType == typeof(DateTime?))
					{
						property.SetValueConverter(nullableDateTimeConverter);
					}
				}
			}
		}

		private static void SoftDeleted(EntityEntry entityEntry)
		{
			if (entityEntry?.Entity is not null
				&& entityEntry.Entity is ISoftDeletable softDeleteable)
			{
				softDeleteable.IsDeleted = true;
				entityEntry.State = EntityState.Modified;
			}
		}

		private void OnSave(EntityEntry entityEntry)
		{
			// TODO: вынести в домен
			if (entityEntry.State != EntityState.Unchanged)
			{
				UpdateTimestamp(entityEntry);
				SetModifiedUser(entityEntry);
			}

			if (entityEntry.State == EntityState.Deleted)
				SoftDeleted(entityEntry);
		}

		private void UpdateTimestamp(EntityEntry entityEntry)
		{
			var entity = entityEntry.Entity;
			if (entity is null)
				return;

			// TODO: лучше бы вызывать функцию бд now() at time zone 'utc', но не нашел как адекватно вмешаться в апдейт
			if (entity is EntityBase table)
			{
				table.ModifiedOn = _dateTimeProvider.UtcNow;
				if (entityEntry.State == EntityState.Added)
					table.CreatedOn = _dateTimeProvider.UtcNow;
			}
		}

		private void SetModifiedUser(EntityEntry entityEntry)
		{
			if (entityEntry?.Entity != null
				&& entityEntry.State != EntityState.Unchanged
				&& entityEntry.Entity is IUserTrackable userTrackable)
			{
				userTrackable.ModifiedByUserId = _userContext.CurrentUserId;

				if (entityEntry.State == EntityState.Added)
					userTrackable.CreatedByUserId = _userContext.CurrentUserId;
			}
		}
	}
}
