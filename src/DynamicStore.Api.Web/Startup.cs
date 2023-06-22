using DynamicStore.Api.Core;
using DynamicStore.Api.Data.PostgreSql;
using DynamicStore.Api.Data.RabbitMq;
using DynamicStore.Api.Data.S3;
using DynamicStore.Api.Web.Authentication;
using DynamicStore.Api.Web.AutoMapper;
using DynamicStore.Api.Web.Cors;
using DynamicStore.Api.Web.HealthChecks;
using DynamicStore.Api.Web.HttpCache;
using DynamicStore.Api.Web.Logging;
using DynamicStore.Api.Web.Options;
using DynamicStore.Api.Web.ResponseCompression;
using DynamicStore.Api.Web.Serialization;
using DynamicStore.Api.Web.Swagger;
using DynamicStore.Api.Web.Versioning;
using DynamicStore.Api.Worker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DynamicStore.Api.Web
{
	/// <summary>
	/// Стартап веб-сервиса
	/// </summary>
	public class Startup
	{
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _webHostEnvironment;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="configuration">Конфигурация</param>
		/// <param name="webHostEnvironment">Окружение и его переменные</param>
		public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			_configuration = configuration;
			_webHostEnvironment = webHostEnvironment;
		}

		/// <summary>
		/// Конфигурация служб и зависимостей ASP.NET Core
		/// http://blogs.msdn.com/b/webdev/archive/2014/06/17/dependency-injection-in-asp-net-vnext.aspx
		/// </summary>
		/// <param name="services">Службы</param>
		public virtual void ConfigureServices(IServiceCollection services) =>
			services
				.AddCustomCaching()
				.AddCustomCors()
				.AddCustomOptions(_configuration)
				.AddRouting()
				.AddResponseCaching()
				.AddCustomResponseCompression(_configuration)
				.AddCustomHealthChecks()
				.AddCustomSwagger()
				.AddHttpContextAccessor()
				.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
				.AddCustomApiVersioning()
				.AddControllers()
					.AddCustomJsonOptions(_webHostEnvironment)
				.AddCustomMvcOptions(_configuration)
				.Services
				.AddCustomAutoMapper()
				.AddUserContext()
				.AddPostgreSql(x =>
				{
					x.ConnectionString = _configuration["Application:DbConnectionString"];
					x.SqlLoggerFactory = _webHostEnvironment.IsDevelopment()
						? LoggerFactory.Create(builder => builder.AddConsole())
						: null;
				})
				.AddRabbitMq(_configuration["Application:RmqConnectionString"])
				.AddHangfireWorker()
				.AddS3Storage(_configuration.GetSection("Application:S3").Get<S3Options>())
				.AddCore()
				.AddCustomAuthentication();

		/// <summary>
		/// Конфигурация пайплайна обработки запроса ASP.NET Core
		/// </summary>
		/// <param name="application">Билдер приложения</param>
		public virtual void Configure(IApplicationBuilder application) =>
			application
				.UseHangfireWorker(_webHostEnvironment.IsDevelopment())
				.UseForwardedHeaders()
				.UseRouting()
				.UseCors(CorsPolicies.AllowAny)
				.UseResponseCaching()
				.UseResponseCompression()
				.UseStaticFilesWithCacheControl()
				.UsePrometheusHealthcheck()
				.UseCustomSerilogRequestLogging()
				.UseExceptionHandling()
				.UseAuthentication()
				.UseAuthorization()
				.UseEndpoints(
					builder =>
					{
						builder.MapControllers().RequireCors(CorsPolicies.AllowAny);
						builder.AddHealthcheckEndpoints();
					})
				.UseCustomSwagger();
	}
}
