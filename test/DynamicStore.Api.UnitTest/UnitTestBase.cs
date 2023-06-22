using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using DynamicStore.Api.Core;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Enums;
using DynamicStore.Api.Core.Models;
using DynamicStore.Api.UnitTest.Mocks;
using DynamicStore.Api.Web.AutoMapper;
using AutoMapper;
using DynamicStore.Api.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using DynamicStore.Api.Data.PostgreSql;
using Moq;
using Serilog;
using Serilog.Events;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest
{
	/// <summary>
	/// Базовый класс для unit-тестов
	/// </summary>
	public class UnitTestBase : IDisposable
	{
		/// <summary>
		/// Токен
		/// </summary>
		protected const string AuthenticationToken = "AuthenticationToken";

		/// <summary>
		/// Контекст текущего пользователя
		/// </summary>
		protected Mock<IUserContext> UserContext { get; private set; }

		/// <summary>
		/// Диспетче событий (TODO: иногда есть смысл диспетчить их, иногда нет)
		/// </summary>
		protected Mock<IMediator> DomainEventsDispatcher { get; private set; }

		/// <summary>
		/// Провайдер даты и времени
		/// </summary>
		protected Mock<IDateTimeProvider> DateTimeProvider { get; private set; }

		/// <summary>
		/// Адаптер очереди
		/// </summary>
		protected Mock<IRabbitMessagePublisher> RabbitMessagePublisher { get; private set; }

		/// <summary>
		/// Сервис архивации в zip
		/// </summary>
		public Mock<IZipArchiver> ZipArchiver { get; set; }

		/// <summary>
		/// Фабрика ClaimsPrincipal для пользователей
		/// </summary>
		protected Mock<IClaimsIdentityFactory> ClaimsIdentityFactory { get; set; }

		/// <summary>
		/// Сервис работы с токенами
		/// </summary>
		protected Mock<ITokenAuthenticationService> TokenAuthenticationService { get; set; }

		/// <summary>
		/// Сервис хэширования паролей
		/// </summary>
		protected Mock<IPasswordEncryptionService> PasswordEncryptionService { get; set; }

		/// <summary>
		/// Автомаппер
		/// </summary>
		protected IMapper Mapper { get; private set; }

		/// <summary>
		/// Делегат проверки уникальности почтового адреса
		/// </summary>
		protected User.HasUserWithEmail HasUserWithEmail => (_, _) => false;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Назначение для логов</param>
		public UnitTestBase(ITestOutputHelper testOutputHelper)
		{
			DateTimeProvider = new Mock<IDateTimeProvider>();
			DateTimeProvider.Setup(x => x.UtcNow).Returns(new DateTime(2021, 5, 28));

			UserContext = new Mock<IUserContext>();
			UserContext.Setup(x => x.CurrentUserId).Returns(Guid.NewGuid());

			DomainEventsDispatcher = new Mock<IMediator>();
			DomainEventsDispatcher
				.Setup(m => m.Send(It.IsAny<It.IsAnyType>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(default)
				.Verifiable("Доменное событие не было создано");
			DomainEventsDispatcher
				.Setup(m => m.Publish(It.IsAny<It.IsAnyType>(), It.IsAny<CancellationToken>()))
				.Verifiable("Доменное событие не было создано");

			Mapper = new Mapper(new MapperConfiguration(options => options
				.AddCore()
				.AddWeb()));

			RabbitMessagePublisher = new Mock<IRabbitMessagePublisher>();
			ZipArchiver = new Mock<IZipArchiver>();
			ZipArchiver
				.Setup(x => x.ZipAsync(It.IsAny<List<ZipArchiveFile>>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(Array.Empty<byte>());


			ClaimsIdentityFactory = new Mock<IClaimsIdentityFactory>();
			//ClaimsIdentityFactory
			//	.Setup(x => x.CreateClaimsIdentity(It.IsAny()))
			//	.Returns(new ClaimsIdentity());

			TokenAuthenticationService = new Mock<ITokenAuthenticationService>();
			TokenAuthenticationService
				.Setup(x => x.CreateToken(It.IsAny<ClaimsIdentity>(), It.IsAny<TokenTypes>()))
				.Returns(AuthenticationToken);

			PasswordEncryptionService = new Mock<IPasswordEncryptionService>();
			PasswordEncryptionService
				.Setup(x => x.ValidatePassword(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(true);
			PasswordEncryptionService
				.Setup(x => x.EncodePassword(It.IsAny<string>()))
				.Returns<string>(x => x);

			Log.Logger = new LoggerConfiguration()
				.WriteTo.Debug()
				.WriteTo.TestOutput(testOutputHelper, LogEventLevel.Verbose)
				.CreateLogger();
		}

		/// <summary>
		/// Создать мок S3-хранилища в памяти
		/// </summary>
		/// <param name="dbSeeder">Сидер хранилища</param>
		/// <returns>Мок S3</returns>
		protected IS3Service CreateInMemoryS3Service(Action<Dictionary<string, FileContent>> dbSeeder = null)
			=> new S3ServiceMock(dbSeeder);
		/// <summary>
		/// Создать контекст с БД в памяти
		/// </summary>
		/// <param name="dbSeeder">Сидер БД</param>
		/// <param name="dbName">Название</param>
		/// <returns>Контекст EF</returns>
		protected EfContext CreateInMemoryContext(Action<EfContext> dbSeeder = null)
		{
			var options = new DbContextOptionsBuilder<EfContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
				.Options;

			using (var context = new EfContext(options, UserContext.Object, DateTimeProvider.Object, DomainEventsDispatcher.Object))
			{
				dbSeeder?.Invoke(context);
				context.SaveChangesAsync().GetAwaiter().GetResult();
			}

			// возвращаем чистый контекст для тестов
			return new EfContext(options, UserContext.Object, DateTimeProvider.Object, DomainEventsDispatcher.Object);
		}

		/// <inheritdoc/>
		public void Dispose() => GC.SuppressFinalize(this);
	}
}
