using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetMainLayout;
using MediatR;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetMainLayout
{
	/// <summary>
	/// Запрос главной страницы
	/// </summary>
	public class GetMainLayoutQuery : GetMainLayoutResponse, IRequest<GetMainLayoutResponse>
	{
	}
}
