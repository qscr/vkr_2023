using System;

namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests
{
	/// <summary>
	/// Данные о созданном токене аутентификации.
	/// </summary>
	public class TokenResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public TokenResponse()
		{
		}

		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public Guid UserId { get; set; }

		/// <summary>
		/// Является ли владельцем магазина
		/// </summary>
		public bool IsShopOwner { get; set; }

		/// <summary>
		/// Текст токена.
		/// </summary>
		public string? Token { get; set; }

		/// <summary>
		/// Токен для обновления токена.
		/// </summary>
		public string? RefreshToken { get; set; }

		/// <summary>
		/// Время создания токена.
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Тип токена.
		/// </summary>
		public string? TokenType { get; set; }

		/// <summary>
		/// Идентификатор типа токена.
		/// </summary>
		public int TokenTypeId { get; set; }
	}
}
