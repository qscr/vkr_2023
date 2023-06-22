namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register
{
	/// <summary>
	/// Запрос на регистрацию
	/// </summary>
	public class RegisterRequest
	{
		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; } = default!;

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; } = default!;

		/// <summary>
		/// Магазин
		/// </summary>
		public RegisterRequestShop? Shop { get; set; }
	}
}
