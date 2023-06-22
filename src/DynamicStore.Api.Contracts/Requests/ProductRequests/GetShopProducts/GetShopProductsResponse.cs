using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts
{
	/// <summary>
	/// Ответ на запрос <see cref="GetShopProductsRequest"/>
	/// </summary>
	public class GetShopProductsResponse
	{
		public GetShopProductsResponse()
		{
		}

		public GetShopProductsResponse(List<GetShopProductsResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetShopProductsResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}
