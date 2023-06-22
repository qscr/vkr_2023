using System;

namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopLayoutById
{
	/// <summary>
	/// Ответ на запрос получения главной страницы магазина по идентификатору
	/// </summary>
	public class GetShopLayoutByIdResponse
	{
		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Дата активации дизайна
		/// </summary>
		public DateTime ActiveFrom { get; set; }

		/// <summary>
		/// Дизайн страницы в формате JSON
		/// </summary>
		public string LayoutDesign { get; set; } = default!;

		/// <summary>
		/// Ид магазина
		/// </summary>
		public Guid? ShopId { get; set; }
	}
}
