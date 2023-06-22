using System;
using System.Collections.Generic;
using System.Net.Http;
using DynamicStore.Api.Core.Abstractions;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Конфигурация зависимостей для хранилища
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить хранилище файлов на протоколе S3
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <param name="options">Параметры подключения к хранилищу</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddS3Storage(this IServiceCollection services, S3Options options)
		{
			if (options is null)
				throw new ArgumentNullException(nameof(options));
			if (string.IsNullOrWhiteSpace(options.AccessKey))
				throw new ArgumentException(nameof(options.AccessKey));
			if (string.IsNullOrWhiteSpace(options.BucketName))
				throw new ArgumentException(nameof(options.BucketName));
			if (string.IsNullOrWhiteSpace(options.SecretKey))
				throw new ArgumentException(nameof(options.SecretKey));
			if (string.IsNullOrWhiteSpace(options.ServiceUrl))
				throw new ArgumentException(nameof(options.ServiceUrl));

			services.AddSingleton(options);
			services.AddTransient<HttpRequestLogHandler>();
			services.AddSingleton<IS3Service, S3Service>();

			services
				.AddHttpClient<S3HttpClientFactory>(opt => opt.Timeout = options.Timeout)
				.ConfigurePrimaryHttpMessageHandler(() =>
				{
					var handler = new HttpClientHandler();
					if (options.IgnoreCertificateErrors)
						handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
					return handler;
				})
				.AddHttpMessageHandler<HttpRequestLogHandler>()
				.Services
				.AddAWSService<IAmazonS3>(new AWSOptions
				{
					Credentials = new BasicAWSCredentials(options.AccessKey, options.SecretKey),
					DefaultClientConfig =
					{
						ServiceURL = options.ServiceUrl,
						MaxErrorRetry = 0,
					},
				});

			return services;
		}

		/// <summary>
		/// Добавить хранилище файлов на протоколе S3
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <param name="options">Параметры подключения к хранилищу</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddS3Storage(this IServiceCollection services, Action<S3Options> options)
		{
			var storageOptions = new S3Options();
			options?.Invoke(storageOptions);

			return AddS3Storage(services, storageOptions);
		}

		/// <summary>
		/// Добавить проверку на <see cref="S3Service"/>
		/// </summary>
		/// <param name="healthChecksBuilder">Строитель healthcheck'ов</param>
		/// <param name="name">Назвнаие</param>
		/// <param name="failureStatus">Статус ошибки</param>
		/// <param name="tags">Тэги</param>
		/// <returns>Строитель healthcheck'ов с healthcheck'ом для S3</returns>
		// ReSharper disable once UnusedMethodReturnValue.Global
		public static IHealthChecksBuilder AddAwsS3(
			this IHealthChecksBuilder healthChecksBuilder,
			string? name = null,
			HealthStatus? failureStatus = null,
			IEnumerable<string>? tags = null)
				=> healthChecksBuilder.AddCheck<S3HealthCheck>(name ?? nameof(S3HealthCheck), failureStatus, tags ?? Array.Empty<string>());
	}
}
