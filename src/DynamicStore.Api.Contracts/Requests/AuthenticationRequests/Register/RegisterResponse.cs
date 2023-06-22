using System;

namespace DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Register
{
	/// <summary>
	/// Ответ на запрос регистрации
	/// </summary>
	public class RegisterResponse
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public Guid UserId { get; set; }
	}
}
