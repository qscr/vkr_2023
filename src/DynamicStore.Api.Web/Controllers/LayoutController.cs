using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetMainLayout;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopLayoutById;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopsLayouts;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.PutLayoutDesign;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.PutMainLayoutDesign;
using DynamicStore.Api.Contracts.Services;
using DynamicStore.Api.Core.Requests.LayoutRequests.GetMainLayout;
using DynamicStore.Api.Core.Requests.LayoutRequests.GetShopLayoutBuId;
using DynamicStore.Api.Core.Requests.LayoutRequests.GetShopsLayouts;
using DynamicStore.Api.Core.Requests.LayoutRequests.PutLayoutDesign;
using DynamicStore.Api.Core.Requests.LayoutRequests.PutMainLayoutDesign;
using DynamicStore.Api.Web.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DynamicStore.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер дизайнов магазинов
	/// </summary>
	[ApiVersion(ApiVersions.V1)]
	[Authorize]
	public class LayoutController : ApiControllerBase
	{
		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetShopsLayoutsResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetShopsLayoutsResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetShopsLayoutsRequest request,
			CancellationToken cancellationToken)
			=> await mediator.Send(
				new GetShopLayoutQuery
				{
					PageNumber = request.PageNumber,
					PageSize = request.PageSize,
					IsAscending = request.IsAscending,
					OrderBy = request.OrderBy,
				},
				cancellationToken);

		/// <summary>
		/// Получить список сущностей по фильтру
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">Идентификатор дизайна</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet("Shop/{id}")]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetShopLayoutByIdResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetShopLayoutByIdResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			CancellationToken cancellationToken)
			=> await mediator.Send(
				new GetShopLayoutByIdQuery(id), cancellationToken);

		/// <summary>
		/// Получить главный дизайн приложения
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Дизайн главной страницы</returns>
		[HttpGet("Main")]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetMainLayoutResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetMainLayoutResponse> GetMainLayoutAsync(
			[FromServices] IMediator mediator,
			CancellationToken cancellationToken)
			=> await mediator.Send(new GetMainLayoutQuery(), cancellationToken);

		/// <summary>
		/// Обновить сущность по идентификатору
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>-</returns>
		[HttpPut]
		[SwaggerResponse(StatusCodes.Status200OK)]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<Unit> PutAsync(
			[FromServices] IMediator mediator,
			[FromBody] PutLayoutDesignRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? throw new ArgumentNullException(nameof(request))
					: new PutLayoutDesignCommand(
						data: request.Data),
				cancellationToken);

		/// <summary>
		/// Обновить главный дизайн
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>-</returns>
		[HttpPut("Main")]
		[SwaggerResponse(StatusCodes.Status200OK)]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<Unit> PutAsync(
			[FromServices] IMediator mediator,
			[FromBody] PutMainLayoutDesignRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? throw new ArgumentNullException(nameof(request))
					: new PutMainLayoutDesignCommand(
						layoutDesign: request.LayoutDesign),
				cancellationToken);
	}
}
