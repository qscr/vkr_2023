using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using MediatR;

namespace DynamicStore.Api.Core.Requests.AuthenticationRequests.Register
{
	/// <summary>
	/// Обработчик запроса <see cref="RegisterCommand"/>
	/// </summary>
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IPasswordEncryptionService _passwordEncryptionService;
		private readonly User.HasUserWithEmail _hasUserWithEmail;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="passwordEncryptionService">Сервис хэширования паролей</param>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="hasUserWithEmail">Делегат проверки уникальности почтового адреса</param>
		public RegisterCommandHandler(
			IPasswordEncryptionService passwordEncryptionService,
			IDbContext dbContext,
			User.HasUserWithEmail hasUserWithEmail)
		{
			_dbContext = dbContext;
			_passwordEncryptionService = passwordEncryptionService;
			_hasUserWithEmail = hasUserWithEmail;
		}

		/// <inheritdoc/>
		public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var passwordHash = _passwordEncryptionService.EncodePassword(request.Password);

			var user = new User(
				name: request.Name,
				email: request.Email,
				hasUserWithEmail: _hasUserWithEmail,
				passwordHash: passwordHash,
				file: default!);

			if (request.Shop != null)
			{
				var shop = new Shop(
					name: request.Shop.Name,
					owner: user,
					file: default!);
				await _dbContext.Shops.AddAsync(shop, cancellationToken);
			}

			await _dbContext.Users.AddAsync(user, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new RegisterResponse
			{
				UserId = user.Id,
			};
		}
	}
}
