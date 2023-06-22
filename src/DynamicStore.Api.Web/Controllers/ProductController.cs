using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.ProductRequests.DeleteProducts;
using DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts;
using DynamicStore.Api.Contracts.Requests.ProductRequests.PostProduct;
using DynamicStore.Api.Contracts.Requests.ProductRequests.PutProductById;
using DynamicStore.Api.Contracts.Services;
using DynamicStore.Api.Core.Requests.ProductRequests.DeleteProducts;
using DynamicStore.Api.Core.Requests.ProductRequests.GetShopProducts;
using DynamicStore.Api.Core.Requests.ProductRequests.PostProduct;
using DynamicStore.Api.Core.Requests.ProductRequests.PutProductById;
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
	public class ProductController : ApiControllerBase
	{
		/// <summary>
		/// Получить список сущностей
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpGet]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetShopProductsResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<GetShopProductsResponse> GetAsync(
			[FromServices] IMediator mediator,
			[FromQuery] GetShopProductsRequest request,
			CancellationToken cancellationToken)
			=> await mediator.Send(
				new GetShopProductsQuery
				{
					PageNumber = request.PageNumber,
					PageSize = request.PageSize,
					IsAscending = request.IsAscending,
					OrderBy = request.OrderBy,
				},
				cancellationToken);

		/// <summary>
		/// Создать товар магазина
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpPost]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(PostProductResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<PostProductResponse> PostAsync(
			[FromServices] IMediator mediator,
			[FromBody] PostProductRequest request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new PostProductCommand(
					name: request.Name,
					description: request.Description,
					price: request.Price,
					photoIds: request.PhotoIds),
				cancellationToken);
		}

		/// <summary>
		/// Обновить сущность по идентификатору
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">Идентификатор сущности</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>-</returns>
		[HttpPut("{id}")]
		[SwaggerResponse(StatusCodes.Status200OK)]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<Unit> PutAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			[FromBody] PutProductByIdRequest request,
			CancellationToken cancellationToken) =>
			await mediator.Send(
				request == null
					? throw new ArgumentNullException(nameof(request))
					: new PutProductByIdCommand(id: id, request: request),
				cancellationToken);

		/// <summary>
		/// Удаление товаров магазина
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список сущностей</returns>
		[HttpDelete]
		[SwaggerResponse(StatusCodes.Status200OK)]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task DeleteAsync(
			[FromServices] IMediator mediator,
			[FromBody] DeleteProductsRequest request,
			CancellationToken cancellationToken)
			=> await mediator.Send(new DeleteProductsCommand(request), cancellationToken);
	}
}
