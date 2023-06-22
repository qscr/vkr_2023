using System.Collections.Generic;
using DynamicStore.Api.Contracts.Messages;
using DynamicStore.Api.Data.RabbitMq.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DynamicStore.Api.Data.RabbitMq
{
	/// <summary>
	/// Класс - входная точка проекта, регистрирующий реализованные зависимости текущим проектом
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить службы проекта с очередью
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <param name="connectionString">Строка подключения к RMQ</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddRabbitMq(this IServiceCollection services, string connectionString)
			=> services.AddMassTransit(connectionString, options => options
				.AddConsumer<UpdateCarDataMessage, UpdateCarDataConsumer>()
				.AddProducer<UpdateCarDataMessage>());

		/// <summary>
		/// Добавить healthcheck на RabbitMQ
		/// </summary>
		/// <param name="healthChecksBuilder">Строитель healthcheck'ов</param>
		/// <param name="name">Назвнаие</param>
		/// <param name="failureStatus">Статус ошибки</param>
		/// <param name="tags">Тэги</param>
		/// <returns>Строитель healthcheck-ов</returns>
		public static IHealthChecksBuilder AddRabbitMq(
			this IHealthChecksBuilder healthChecksBuilder,
			string? name = null,
			HealthStatus? failureStatus = null,
			IEnumerable<string>? tags = null)
				=> healthChecksBuilder.AddRabbitMQ(name, failureStatus, tags);
	}
}
