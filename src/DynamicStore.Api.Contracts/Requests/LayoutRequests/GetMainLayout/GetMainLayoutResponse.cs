using System;

namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.GetMainLayout
{
	/// <summary>
	/// Дизайн магазина
	/// </summary>
	public class GetMainLayoutResponse
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
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }
	}
}
