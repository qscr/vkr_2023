using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicStore.Api.Web.Authentication
{
	/// <summary>
	/// Точка входа сервисов аутентификации для приложения
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить контекст пользователя в службы приложения
		/// </summary>
		/// <param name="services">Службы приложения</param>
		/// <returns>Службы приложения с контекстом текущего пользователя</returns>
		public static IServiceCollection AddUserContext(this IServiceCollection services) =>
			services
				.AddScoped<IUserContext, UserContext>();

		/// <summary>
		/// Добавить аутентификацию по хэдерам
		/// </summary>
		/// <param name="services">Службы приложения</param>
		public static void AddCustomAuthentication(this IServiceCollection services)
			=> services
				.AddAuthentication(options =>
				{
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					var tokenService = services.BuildServiceProvider().GetRequiredService<ITokenAuthenticationService>();
					options.Authority = tokenService!.Authority;
					options.Audience = tokenService.Audience;
					options.ClaimsIssuer = tokenService.ClaimsIssuer;
					options.RequireHttpsMetadata = tokenService.RequireHttpsMetadata ?? false;
					options.TokenValidationParameters = tokenService.GetTokenValidationParameters(TokenTypes.Auth);
					options.Configuration = new OpenIdConnectConfiguration();
				});
	}
}
