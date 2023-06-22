using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopsLayouts;
using DynamicStore.Api.Core.Models;
using MediatR;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetShopsLayouts
{
	/// <summary>
	/// Запрос списка дизайнов магазинов
	/// </summary>
	public class GetShopLayoutQuery : GetShopsLayoutsRequest, IRequest<GetShopsLayoutsResponse>, IOrderByQuery, IPaginationQuery
	{
	}
}
