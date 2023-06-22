namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Login
{
	/// <summary>
	/// Запрос на логин.
	/// </summary>
	public class LoginRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="password">Пароль</param>
		public LoginRequest(string email, string password)
		{
			Email = email;
			Password = password;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public LoginRequest()
		{
		}

		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; } = default!;

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; } = default!;
	}
}
