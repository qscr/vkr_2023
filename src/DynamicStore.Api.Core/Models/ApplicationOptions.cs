namespace DynamicStore.Api.Core.Models
{
	/// <summary>
	/// Конфигурация приложения
	/// </summary>
	public class ApplicationOptions
	{

		/// <summary>
		/// Соль для хэширования пароля
		/// </summary>
		public string PasswordHashSalt { get; set; } = default!;
	}
}
