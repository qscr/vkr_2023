using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopsLayouts
{
	/// <summary>
	/// Ответ на запрос списка дизайнов магазинов
	/// </summary>
	public class GetShopsLayoutsResponse
	{
		public GetShopsLayoutsResponse()
		{
		}

		public GetShopsLayoutsResponse(List<GetShopsLayoutsResponseItem> entities, int totalCount)
		{
			Entities = entities;
			TotalCount = totalCount;
		}

		/// <summary>
		/// Список сущностей
		/// </summary>
		public List<GetShopsLayoutsResponseItem> Entities { get; set; } = default!;

		/// <summary>
		/// Общее количество сущностей
		/// </summary>
		public int TotalCount { get; set; }
	}
}
