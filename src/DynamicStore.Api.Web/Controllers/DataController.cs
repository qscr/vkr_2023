using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData;
using DynamicStore.Api.Contracts.Requests.DataRequests.GetShopData;
using DynamicStore.Api.Contracts.Services;
using DynamicStore.Api.Core.Requests.DataRequests.GetMainData;
using DynamicStore.Api.Core.Requests.DataRequests.GetShopDataById;
using DynamicStore.Api.Web.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DynamicStore.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер магазинов
	/// </summary>
	[ApiVersion(ApiVersions.V1)]
	[Authorize]
	public class DataController : ApiControllerBase
	{
		/// <summary>
		/// Получить данные по главной странице
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet("Main")]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetMainDataResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetMainDataResponse> GetAsync(
			[FromServices] IMediator mediator,
			CancellationToken cancellationToken)
			=> await mediator.Send(new GetMainDataQuery(), cancellationToken);

		/// <summary>
		/// Получить данные по странице магазина по ид
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">Идентификатор дизайна</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet("{id}")]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetShopDataByIdResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetShopDataByIdResponse> GetByIdAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			CancellationToken cancellationToken)
			=> await mediator.Send(new GetShopDataByIdQuery(id), cancellationToken);
	}
}
