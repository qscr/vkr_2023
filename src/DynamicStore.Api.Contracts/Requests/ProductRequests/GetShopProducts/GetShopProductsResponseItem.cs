using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts
{
	/// <summary>
	/// Ответ на запрос получения всех товаров магазина
	/// </summary>
	public class GetShopProductsResponseItem
	{
		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Наименование товара
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Описание товара
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Цена товара
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Ид фотографий товара
		/// </summary>
		public List<Guid>? PhotoIds { get; set; }

		/// <summary>
		/// Ид категорий товара
		/// </summary>
		public List<Guid>? CategoryIds { get; set; }
	}
}
