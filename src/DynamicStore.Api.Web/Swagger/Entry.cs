using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DynamicStore.Api.Web.Swagger
{
	/// <summary>
	/// Точка входа сервисов swagger для приложения
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить в службы приложения swagger
		/// </summary>
		/// <param name="services">Службы приложения</param>
		/// <returns>Службы приложения со сваггером</returns>
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services) =>
			services
				.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
				.AddSwaggerGen(c =>
				{
					c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
					{
						Name = "Authorization",
						In = ParameterLocation.Header,
						Type = SecuritySchemeType.Http,
						Scheme = "bearer",
					});

					c.AddSecurityRequirement(new OpenApiSecurityRequirement()
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer",
								},
							},
							new List<string>()
						},
					});
				});

		/// <summary>
		/// Добавить кастомный UI сваггера
		/// </summary>
		/// <param name="application">Пайплайн приложения</param>
		/// <returns>Пайплайн приложения со сваггером</returns>
		public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder application) =>
			application
				.UseSwagger()
				.UseSwaggerUI(
					options =>
					{
						options.DocumentTitle = AssemblyInformation.Current.Product;
						options.RoutePrefix = "swagger";
						options.DisplayOperationId();
						options.DisplayRequestDuration();

						var provider = application.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
						foreach (var apiVersionDescription in provider
							.ApiVersionDescriptions
							.OrderByDescending(x => x.ApiVersion))
						{
							options.SwaggerEndpoint(
								$"/swagger/{apiVersionDescription.GroupName}/swagger.json",
								$"Version {apiVersionDescription.ApiVersion}");
						}
					});
	}
}
