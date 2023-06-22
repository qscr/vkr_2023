using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Enums;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.RefreshToken
{
	/// <summary>
	/// Обработчик запроса <see cref="RefreshTokenCommand"/>
	/// </summary>
	public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly ITokenAuthenticationService _tokenAuthenticationService;
		private readonly IUserContext _userContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="dateTimeProvider">Провайдер даты</param>
		/// <param name="tokenAuthenticationService">Сервис работы с токенами</param>
		/// <param name="userContext">Контекст пользователя</param>
		public RefreshTokenCommandHandler(
			IDbContext dbContext,
			IDateTimeProvider dateTimeProvider,
			ITokenAuthenticationService tokenAuthenticationService,
			IUserContext userContext)
		{
			_dbContext = dbContext;
			_dateTimeProvider = dateTimeProvider;
			_tokenAuthenticationService = tokenAuthenticationService;
			_userContext = userContext;
		}

		/// <inheritdoc/>
		public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));
			if (request.RefreshToken is null)
				throw new ArgumentNullException(nameof(request.RefreshToken));

			var principal = _tokenAuthenticationService.ValidateToken(request.RefreshToken, TokenTypes.RefreshToken);
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));

			var userId = new Guid(principal.Claims.First().Value);

			var user = await _dbContext.Users
				.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken)
				?? throw new EntityNotFoundException<User>(userId);

			var claimsIdentity = new ClaimsIdentity(claims: principal.Claims.ToList());
			var authToken = _tokenAuthenticationService.CreateToken(claimsIdentity, TokenTypes.Auth);
			var refreshToken = _tokenAuthenticationService.CreateToken(claimsIdentity, TokenTypes.RefreshToken);

			return new TokenResponse
			{
				UserId = user.Id,
				TokenTypeId = (int)TokenTypes.Auth,
				CreatedOn = _dateTimeProvider.UtcNow,
				Token = authToken,
				RefreshToken = refreshToken,
				TokenType = _tokenAuthenticationService.AuthTokenType,
			};
		}
	}
}
