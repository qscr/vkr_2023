using System.Collections.Generic;

namespace DynamicStore.Api.Core.Models
{
	/// <summary>
	/// Модель пользователя для Firebase
	/// </summary>
	public class FirebaseUser
	{
		/// <summary>
		/// Сообщение
		/// </summary>
		public string Message { get; } = default!;

		/// <summary>
		/// Список токенов
		/// </summary>
		public List<string>? MobileApplicationTokens { get; set; }
	}
}
