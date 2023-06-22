using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Контекст EF Core для приложения
	/// </summary>
	public interface IDbContext
	{
		#region Entities

		/// <summary>
		/// Рекламы
		/// </summary>
		DbSet<Advertising> Advertisements { get; }

		/// <summary>
		/// Категории
		/// </summary>
		DbSet<Category> Categories { get; }

		/// <summary>
		/// Файлы
		/// </summary>
		DbSet<File> Files { get; }

		/// <summary>
		/// Дизайны магазинов
		/// </summary>
		DbSet<Layout> Layouts { get; }

		/// <summary>
		/// Заказы
		/// </summary>
		DbSet<Order> Orders { get; }

		/// <summary>
		/// Товары в заказах
		/// </summary>
		DbSet<OrderProduct> OrderProducts { get; }

		/// <summary>
		/// Товары
		/// </summary>
		DbSet<Product> Products { get; }

		/// <summary>
		/// Магазины
		/// </summary>
		DbSet<Shop> Shops { get; }

		/// <summary>
		/// Пользователи
		/// </summary>
		DbSet<User> Users { get; }

		#endregion

		/// <summary>
		/// БД в памяти
		/// </summary>
		bool IsInMemory { get; }

		/// <summary>
		/// Очистить UnitOfWork
		/// </summary>
		void Clean();

		/// <summary>
		/// Сохранить изменения в БД
		/// </summary>
		/// <param name="acceptAllChangesOnSuccess">Применить изменения при успешном сохранении в контекст</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Количество обновленных записей</returns>
		Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

		/// <summary>
		/// Сохранить изменения в БД
		/// </summary>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Количество обновленных записей</returns>
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
