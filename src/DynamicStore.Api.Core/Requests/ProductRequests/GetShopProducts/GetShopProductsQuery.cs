using DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts;
using DynamicStore.Api.Core.Models;
using MediatR;

namespace DynamicStore.Api.Core.Requests.ProductRequests.GetShopProducts
{
	/// <summary>
	/// Запрос списка товаров магазина
	/// </summary>
	public class GetShopProductsQuery : GetShopProductsRequest, IRequest<GetShopProductsResponse>, IOrderByQuery, IPaginationQuery
	{
	}
}
