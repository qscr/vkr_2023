using System;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Категория
	/// </summary>
	public class GetMainDataResponseCategory
	{
		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Код категории
		/// </summary>
		public string Code { get; set; } = default!;

		/// <summary>
		/// Наименование категории
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Описание категории
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }
	}
}
