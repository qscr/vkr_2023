using System.Linq;
using System.Text;
using AutoMapper;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.AutoMapper;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicStore.Api.Core
{
	/// <summary>
	/// Класс - входная точка проекта, регистрирующий реализованные зависимости текущим проектом
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить службы проекта с логикой
		/// </summary>
		/// <param name="services">Коллекция служб</param>
		/// <returns>Обновленная коллекция служб</returns>
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			// регистрируем нестандартные кодировки
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			services.AddMediatR(typeof(Entry));
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
			services.AddScoped<ITokenAuthenticationService, TokenAuthenticationService>();
			services.AddScoped<IClaimsIdentityFactory, ClaimsIdentityFactory>();
			services.AddSingleton<IPasswordEncryptionService, PasswordEncryptionService>();
			services.AddScoped<IZipArchiver, ZipArchiver>();
			services.AddSingleton<IFirebaseAdmin, Services.FirebaseAdmin>();
			services.AddScoped<IAuthorizationService, AuthorizationService>();
			services.AddUniqueDelegates();

			return services;
		}

		private static void AddUniqueDelegates(this IServiceCollection services) => services.AddScoped<User.HasUserWithEmail>(
				sp => (email, user)
					=> sp.GetRequiredService<IDbContext>()
						.Users
						.Any(u => u.Email == email && u.Id != user.Id));

		/// <summary>
		/// Добавить конфигурации автомаппера
		/// </summary>
		/// <param name="mapper">Билдер автомаппера</param>
		/// <returns>Билдер автомаппера с конфигурацией</returns>
		public static IMapperConfigurationExpression AddCore(this IMapperConfigurationExpression mapper)
		{
			mapper.AddProfile(new MappingProfile());
			return mapper;
		}
	}
}
