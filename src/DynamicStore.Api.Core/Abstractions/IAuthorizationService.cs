using System.Linq;
using DynamicStore.Api.Core.Entities;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Сервис проверки прав доступа
	/// </summary>
	public interface IAuthorizationService
	{
		/// <summary>
		/// Отфильтровать дизайны для изменения в зависимости от прав доступа
		/// </summary>
		/// <param name="query">Запрос</param>
		/// <returns>Отфильтрованный запрос</returns>
		IQueryable<Layout> FilterUpdateLayout(IQueryable<Layout> query);

		/// <summary>
		/// Отфильтровать дизайны главной страницы для изменения в зависимости от прав доступа
		/// </summary>
		/// <param name="query">Запрос</param>
		/// <returns>Отфильтрованный запрос</returns>
		IQueryable<Layout> FilterUpdateMainLayout(IQueryable<Layout> query);

		/// <summary>
		/// Отфильтровать товары для изменения в зависимости от прав доступа
		/// </summary>
		/// <param name="query">Запрос</param>
		/// <returns>Отфильтрованный запрос</returns>
		IQueryable<Product> FilterUpdateProducts(IQueryable<Product> query);
	}
}
