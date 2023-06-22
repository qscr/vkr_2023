using DynamicStore.Api.Core.Models;
using DynamicStore.Api.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DynamicStore.Api.Web.Options
{
	/// <summary>
	/// Точка входа опций конфигурации для приложения
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Configures the settings by binding the contents of the appsettings.json file to the specified Plain Old CLR
		/// Objects (POCO) and adding <see cref="IOptions{T}"/> objects to the services collection.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>The services with options services added.</returns>
		public static IServiceCollection AddCustomOptions(
			this IServiceCollection services,
			IConfiguration configuration) =>
			services
				.ConfigureAndValidateSingleton<GlobalOptions>(configuration)
				.ConfigureAndValidateSingleton<CompressionOptions>(configuration.GetSection(nameof(GlobalOptions.Compression)))
				.ConfigureAndValidateSingleton<ForwardedHeadersOptions>(configuration.GetSection(nameof(GlobalOptions.ForwardedHeaders)))
				.Configure<ForwardedHeadersOptions>(
					options =>
					{
						options.KnownNetworks.Clear();
						options.KnownProxies.Clear();
					})
				.ConfigureAndValidateSingleton<ApplicationOptions>(configuration.GetSection(nameof(GlobalOptions.Application)))
				.ConfigureAndValidateSingleton<AuthenticationTokenOptions>(configuration.GetSection(nameof(GlobalOptions.Token)))
				.ConfigureAndValidateSingleton<FirebaseServiceAccountOptions>(configuration.GetSection(nameof(GlobalOptions.FirebaseServiceAccount)))
				.ConfigureAndValidateSingleton<CacheProfileOptions>(configuration.GetSection(nameof(GlobalOptions.CacheProfiles)))
				.ConfigureAndValidateSingleton<KestrelServerOptions>(configuration.GetSection(nameof(GlobalOptions.Kestrel)));
	}
}
