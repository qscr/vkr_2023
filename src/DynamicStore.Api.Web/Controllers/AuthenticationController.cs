using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Login;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.RefreshToken;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register;
using DynamicStore.Api.Contracts.Services;
using DynamicStore.Api.Core.Requests.AuthenticationRequests.Login;
using DynamicStore.Api.Core.Requests.AuthenticationRequests.RefreshToken;
using DynamicStore.Api.Core.Requests.AuthenticationRequests.Register;
using DynamicStore.Api.Web.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DynamicStore.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер для аутентификации
	/// </summary>
	[ApiVersion(ApiVersions.V1)]
	public class AuthenticationController : ApiControllerBase
	{
		/// <summary>
		/// Регистрация в системе
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Идентификатор пользователя</returns>
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(RegisterResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		[HttpPost("Register")]
		public async Task<RegisterResponse> RegisterAsync(
			[FromServices] IMediator mediator,
			[FromBody] RegisterRequest request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new RegisterCommand
				{
					Name = request.Name,
					Email = request.Email,
					Password = request.Password,
					Shop = request.Shop,
				},
				cancellationToken);
		}

		/// <summary>
		/// Вход в систему
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>JWT-токены</returns>
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(TokenResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		[HttpPost("Login")]
		public async Task<TokenResponse> LoginAsync(
			[FromServices] IMediator mediator,
			[FromBody] LoginRequest request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new LoginCommand
				{
					Email = request.Email,
					Password = request.Password,
				},
				cancellationToken);
		}

		/// <summary>
		/// Обновить токен
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="request">Запрос</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>JWT-токены</returns>
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(TokenResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		[HttpPost("RefreshToken")]
		public async Task<TokenResponse> RefreshTokenAsync(
			[FromServices] IMediator mediator,
			[FromBody] RefreshTokenRequest request,
			CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			return await mediator.Send(
				new RefreshTokenCommand()
				{
					Token = request.Token,
					RefreshToken = request.RefreshToken,
				},
				cancellationToken);
		}
	}
}
