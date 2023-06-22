using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DynamicStore.Api.Data.PostgreSql;
using DynamicStore.Api.Data.S3;
using DynamicStore.Api.Web.Cors;
using DynamicStore.Api.Worker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DynamicStore.Api.Web.HealthChecks
{
	/// <summary>
	/// Точка входа сервисов HealthCheck-ов для приложения
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить службы HealthCheck-ов
		/// </summary>
		/// <param name="services">Коллекция служб приложения</param>
		/// <returns>Коллекция служб приложения с HealthChecks</returns>
		public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services) =>
			services
				.AddHealthChecks()
				.AddPostgreSql("postgresql", HealthStatus.Unhealthy, new string[] { "external", "db" })
				// RMQ дбавлен в HealthCheck MassTransit. для отдельного healthcheck'а на RMQ раскомментить
				// .AddRabbitMq("rabbitmq", HealthStatus.Unhealthy, new string[] { "external", "queue" })
				.AddAwsS3("s3", HealthStatus.Unhealthy, new string[] { "external", "storage" })
				.AddHangfireWorker("hangfire", HealthStatus.Unhealthy, new string[] { "external", "worker" })
				// TODO: https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks
				// осторожнее настраивайте healthcheck'и - они могут аффектить старт контейнера в приложении
				// https://developers.redhat.com/blog/2020/11/10/you-probably-need-liveness-and-readiness-probes#what_are_readiness_probes_for_
				.Services;

		/// <summary>
		/// Выгрузить результаты метрик в формате prometheus
		/// </summary>
		/// <param name="app">Строитель пайплайна приложения</param>
		/// <returns>Строитель пайплайна приложения с экспортером healthcheck в prometheus</returns>
		public static IApplicationBuilder UsePrometheusHealthcheck(this IApplicationBuilder app) =>
			app.UseHealthChecksPrometheusExporter("/metrics/health");

		/// <summary>
		/// Создать эндпоинты для readiness probe и liveness probe
		/// </summary>
		/// <param name="builder">Строитель пайплайна приложения</param>
		/// <param name="readinessProbeUrl">URL readiness probe</param>
		/// <param name="livenessProbeUrl">URL liveness probe</param>
		/// <returns>Строитель пайплайна приложения с readiness probe и liveness probe</returns>
		public static IEndpointRouteBuilder AddHealthcheckEndpoints(
			this IEndpointRouteBuilder builder,
			string readinessProbeUrl = "/health",
			string livenessProbeUrl = "/health/live")
		{
			builder
				.MapHealthChecks(readinessProbeUrl, new HealthCheckOptions
				{
					ResponseWriter = WriteResponseAsync,
				})
				.RequireCors(CorsPolicies.AllowAny);
			builder
				.MapHealthChecks(livenessProbeUrl, new HealthCheckOptions
				{
					ResponseWriter = WriteResponseAsync,
					Predicate = _ => false,
				})
				.RequireCors(CorsPolicies.AllowAny);
			return builder;
		}

		private static Task WriteResponseAsync(HttpContext context, HealthReport result)
		{
			context.Response.ContentType = "application/json; charset=utf-8";

			var options = new JsonWriterOptions
			{
				Indented = true,
			};

			using (var stream = new MemoryStream())
			{
				using (var writer = new Utf8JsonWriter(stream, options))
				{
					writer.WriteStartObject();
					writer.WriteString("status", result.Status.ToString());
					writer.WriteStartObject("results");
					foreach (var entry in result.Entries)
					{
						writer.WriteStartObject(entry.Key);
						writer.WriteString("status", entry.Value.Status.ToString());
						writer.WriteString("description", entry.Value.Description);
						writer.WriteStartObject("data");
						foreach (var item in entry.Value.Data)
						{
							writer.WritePropertyName(item.Key);
							JsonSerializer.Serialize(
								writer, item.Value, item.Value?.GetType() ?? typeof(object));
						}
						writer.WriteEndObject();
						writer.WriteEndObject();
					}
					writer.WriteEndObject();
					writer.WriteEndObject();
				}

				var json = Encoding.UTF8.GetString(stream.ToArray());

				return context.Response.WriteAsync(json);
			}
		}
	}
}
