using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Enums;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.Login
{
	/// <summary>
	/// Обработчик запроса <see cref="LoginCommand"/>
	/// </summary>
	public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IClaimsIdentityFactory _claimsIdentityFactory;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly ITokenAuthenticationService _tokenAuthenticationService;
		private readonly IPasswordEncryptionService _passwordEncryptionService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="passwordEncryptionService">Сервис хеширования паролей</param>
		/// <param name="dateTimeProvider">Провайдер даты</param>
		/// <param name="claimsIdentityFactory">Фабрика клеймов</param>
		/// <param name="tokenAuthenticationService">Сервис работы с токенами</param>
		public LoginCommandHandler(
			IDbContext dbContext,
			IPasswordEncryptionService passwordEncryptionService,
			IDateTimeProvider dateTimeProvider,
			IClaimsIdentityFactory claimsIdentityFactory,
			ITokenAuthenticationService tokenAuthenticationService)
		{
			_dbContext = dbContext;
			_claimsIdentityFactory = claimsIdentityFactory;
			_dateTimeProvider = dateTimeProvider;
			_tokenAuthenticationService = tokenAuthenticationService;
			_passwordEncryptionService = passwordEncryptionService;
		}

		/// <inheritdoc/>
		public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var user = await _dbContext.Users
				.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
				?? throw new NotFoundException("Не найден пользователь");

			var isPasswordCorrect = _passwordEncryptionService.ValidatePassword(request.Password, user.PasswordHash);
			if (!isPasswordCorrect)
				throw new ApplicationExceptionBase("Некорректный пароль пользователя");

			var claimsIdentity = _claimsIdentityFactory.CreateClaimsIdentity(user);
			var authToken = _tokenAuthenticationService.CreateToken(claimsIdentity, TokenTypes.Auth);
			var refreshToken = _tokenAuthenticationService.CreateToken(claimsIdentity, TokenTypes.RefreshToken);

			return new TokenResponse
			{
				UserId = user.Id,
				IsShopOwner = user.ShopId != null,
				TokenTypeId = (int)TokenTypes.Auth,
				CreatedOn = _dateTimeProvider.UtcNow,
				Token = authToken,
				RefreshToken = refreshToken,
				TokenType = _tokenAuthenticationService.AuthTokenType,
			};
		}
	}
}
