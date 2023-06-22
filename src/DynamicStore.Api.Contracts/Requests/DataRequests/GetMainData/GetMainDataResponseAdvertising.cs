using System;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Реклама
	/// </summary>
	public class GetMainDataResponseAdvertising
	{
		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Путь
		/// </summary>
		public string Route { get; set; } = default!;

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid FileId { get; set; }
	}
}
