using DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData;
using MediatR;

namespace DynamicStore.Api.Core.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Запрос данных с главной страницы
	/// </summary>
	public class GetMainDataQuery : GetMainDataResponse, IRequest<GetMainDataResponse>
	{
	}
}
