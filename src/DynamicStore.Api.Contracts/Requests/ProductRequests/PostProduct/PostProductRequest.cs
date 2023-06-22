using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.PostProduct
{
	/// <summary>
	/// Запрос на создание товара
	/// </summary>
	public class PostProductRequest
	{
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
	}
}
