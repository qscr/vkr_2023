namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests.RefreshToken
{
	/// <summary>
	/// RefreshToken
	/// </summary>
	public class RefreshTokenRequest
	{
		/// <summary>
		/// Текст токена
		/// </summary>
		public string? Token { get; set; }

		/// <summary>
		/// Токен для обновления токена
		/// </summary>
		public string? RefreshToken { get; set; }
	}
}
