using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Ответ на запрос получения данных о стартовой странице
	/// </summary>
	public class GetMainDataResponse
	{
		/// <summary>
		/// Магазины
		/// </summary>
		public List<GetMainDataResponseShop>? Shops { get; set; }

		/// <summary>
		/// Товары
		/// </summary>
		public List<GetMainDataResponseProduct>? Products { get; set; }

		/// <summary>
		/// Рекламы
		/// </summary>
		public List<GetMainDataResponseAdvertising>? Advertisements { get; set; }

		/// <summary>
		/// Категории
		/// </summary>
		public List<GetMainDataResponseCategory>? Categories { get; set; }
	}
}
