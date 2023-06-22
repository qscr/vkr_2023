using System;
using DynamicStore.Api.Client.Services;
using DynamicStore.Api.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicStore.Api.Client
{
	/// <summary>
	/// Класс - входная точка проекта, регистрирующий реализованные зависимости текущим проектом
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Регистрация зависимостей для клиентской библиотеки микросервиса
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <param name="optionsAction">Параметры клиента</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddMicroserviceClient<TOptions>(
			this IServiceCollection services,
			Action<TOptions>? optionsAction)
			where TOptions : HttpApiClientOptions, new()
		{
			var options = new TOptions();
			optionsAction?.Invoke(options);

			return services.AddMicroserviceClient(options);
		}

		/// <summary>
		/// Регистрация зависимостей для клиентской библиотеки микросервиса
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <param name="options">Параметры клиента</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddMicroserviceClient<TOptions>(
			this IServiceCollection services,
			TOptions options)
			where TOptions : HttpApiClientOptions, new()
		{
			if (string.IsNullOrWhiteSpace(options.Origin))
				throw new ArgumentException(nameof(options.Origin));
			if (string.IsNullOrWhiteSpace(options.BaseUrl))
				throw new ArgumentException(nameof(options.BaseUrl));
			if (options.Timeout.TotalMilliseconds == 0)
				throw new ArgumentException(nameof(options.Timeout));

			services
				// TODO: configure request logging
				.AddHttpClient<IMicroserviceClient, MicroserviceClient>(client =>
				{
					client.BaseAddress = new Uri(options.BaseUrl);
					client.Timeout = options.Timeout;
					client.DefaultRequestHeaders.Add("X-System-Origin", Uri.EscapeDataString(options.Origin));
				});

			return services;
		}
	}
}
