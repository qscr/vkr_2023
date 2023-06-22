using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Товары
	/// </summary>
	public class GetMainDataResponseProduct
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
		/// Ид магазина
		/// </summary>
		public Guid ShopId { get; set; }

		/// <summary>
		/// Ид картинок
		/// </summary>
		public List<Guid>? FileIds { get; set; }
	}
}
