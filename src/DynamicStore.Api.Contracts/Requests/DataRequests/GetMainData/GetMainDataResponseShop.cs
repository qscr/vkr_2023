using System;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Магазины
	/// </summary>
	public class GetMainDataResponseShop
	{
		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Наименование магазина
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Ид владельца магазина
		/// </summary>
		public Guid OwnerId { get; set; }

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }
	}
}
