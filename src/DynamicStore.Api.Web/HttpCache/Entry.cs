using System;
using System.Linq;
using DynamicStore.Api.Web.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicStore.Api.Web.HttpCache
{
	/// <summary>
	/// Точка входа сервисов кэширования http-ответов для приложения
	/// </summary>
	internal static class Entry
	{
		/// <summary>
		/// Добавить пайп кэширования http-ответов (статических файлов) в пайплайн обработки запроса
		/// See http://andrewlock.net/adding-cache-control-headers-to-static-files-in-asp-net-core/.
		/// </summary>
		/// <param name="application">Пайплайн обработки запроса</param>
		/// <returns>Пайплайн обработки запроса с кэшем статики</returns>
		public static IApplicationBuilder UseStaticFilesWithCacheControl(this IApplicationBuilder application)
		{
			var cacheProfile = application
				.ApplicationServices
				.GetRequiredService<CacheProfileOptions>()
				.Where(x => string.Equals(x.Key, CacheProfiles.StaticFiles, StringComparison.Ordinal))
				.Select(x => x.Value)
				.SingleOrDefault();

			return application
				.UseStaticFiles(
					new StaticFileOptions()
					{
						OnPrepareResponse = context =>
						{
							if (cacheProfile is not null)
								context.Context.ApplyCacheProfile(cacheProfile);
						},
					});
		}

		/// <summary>
		/// Добавить кэш <see cref="IDistributedCache"/> и <see cref="IMemoryCache"/>в приложение.
		/// Распределенный кэш юзается для облачных сервисов
		/// </summary>
		/// <param name="services">Коллекция служб приложения</param>
		/// <returns>Коллекция служб приложения с кэшем</returns>
		public static IServiceCollection AddCustomCaching(this IServiceCollection services) =>
			services
				.AddMemoryCache();
	}
}
