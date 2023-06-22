using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using DynamicStore.Api.Core.Requests.AuthenticationRequests.Register;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest.Requests.AuthenticationRequests
{
	/// <summary>
	/// Тест <see cref="RegisterCommandHandler"/>
	/// </summary>
	public class RegisterCommandHandlerTest : UnitTestBase
	{
		private readonly IDbContext _dbContext;
		private readonly User _user;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Логгер</param>
		public RegisterCommandHandlerTest(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{
			_user = User.CreateForTest(
				name: "Name",
				email: "Test@test.ru",
				passwordHash: "TestPassword");
			_dbContext = CreateInMemoryContext(x => x.AddRange(_user));
		}

		/// <summary>
		/// Метод регистрации с повторяющимся email должен бросить исключение
		/// </summary>
		/// <returns>-</returns>
		/// [Fact]
		public async Task Handle_DuplicateLoginRequest_ShouldThrowAsync()
		{
			var request = new RegisterCommand
			{
				Name =_user.Name,
				Email = _user.Email,
				Password = "Password",
			};
			var handler = new RegisterCommandHandler(
				PasswordEncryptionService.Object,
				_dbContext,
				HasUserWithEmail);

			await Assert.ThrowsAsync<ApplicationExceptionBase>(async ()
				=> await handler.Handle(request, default).ConfigureAwait(false));
		}

		/// <summary>
		/// Метод регистрации должен создать пользователя в системе
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_CorrectRequest_ShouldCreateUserAsync()
		{
			var request = new RegisterCommand
			{
				Name = "Name",
				Email = "Test@test.ru",
				Password = "Password",
			};
			var handler = new RegisterCommandHandler(
				PasswordEncryptionService.Object,
				_dbContext,
				HasUserWithEmail);

			var response = await handler.Handle(request, default).ConfigureAwait(false);
			Assert.NotNull(response);

			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == response.UserId);
			Assert.NotNull(user);
			Assert.Equal(request.Name, user.Name);
			Assert.Equal(request.Email, user.Email);
			Assert.Equal(request.Password, user.PasswordHash);
		}
	}
}
