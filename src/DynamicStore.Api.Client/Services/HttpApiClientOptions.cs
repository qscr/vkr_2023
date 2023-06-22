using System;

namespace DynamicStore.Api.Client.Services
{
	/// <summary>
	/// Базовые настройки API клиента
	/// </summary>
	public class HttpApiClientOptions
	{
		/// <summary>
		/// Имя исходного сервиса
		/// </summary>
		public virtual string Origin { get; set; } = default!;

		/// <summary>
		/// Базовый адрес сервиса
		/// </summary>
		public virtual string BaseUrl { get; set; } = default!;

		/// <summary>
		/// Http timeout
		/// </summary>
		public virtual TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(3);
	}
}
