using System;

namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopsLayouts
{
	/// <summary>
	/// Дизайн магазина в ответе на запрос списка дизайнов магазинов
	/// </summary>
	public class GetShopsLayoutsResponseItem
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

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }
	}
}
