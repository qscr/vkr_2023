using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Enums;
using DynamicStore.Api.Core.Requests.AuthenticationRequests.Login;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest.Requests.AuthenticationRequests
{
	/// <summary>
	/// Тест <see cref="LoginCommandHandler"/>
	/// </summary>
	public class LoginCommandHandlerTest : UnitTestBase
	{
		private readonly IDbContext _dbContext;
		private readonly User _user;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Логгер</param>
		public LoginCommandHandlerTest(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{
			_user = User.CreateForTest(
				name: "Name",
				email: "login",
				passwordHash: "hash");

			_dbContext = CreateInMemoryContext(
				x => x.Add(_user));
		}

		/// <summary>
		/// Метод аутентификации зарегистрированного пользователя должен вернуть токен
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_RegisteredUserAuthentication_ShouldReturnToken()
		{
			var command = new LoginCommand()
			{
				Email = _user.Email,
				Password = "123",
			};

			var handler = new LoginCommandHandler(
				_dbContext,
				PasswordEncryptionService.Object,
				DateTimeProvider.Object,
				ClaimsIdentityFactory.Object,
				TokenAuthenticationService.Object);
			var response = await handler.Handle(command, default).ConfigureAwait(false);
			Assert.NotNull(response);

			Assert.Equal(_user.Id, response.UserId);
			Assert.Equal(AuthenticationToken, response.Token);
			Assert.Equal(AuthenticationToken, response.RefreshToken);
			Assert.Equal(DateTimeProvider.Object.UtcNow, response.CreatedOn);
			Assert.Equal(TokenAuthenticationService.Object.AuthTokenType, response.TokenType);
			Assert.Equal((int)TokenTypes.Auth, response.TokenTypeId);
		}
	}
}

