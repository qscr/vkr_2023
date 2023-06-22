using AutoMapper;
using DynamicStore.Api.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicStore.Api.Web.AutoMapper
{
	/// <summary>
	/// Точка входа сервисов CORS для приложения
	/// </summary>
	public static class Entry
	{
		/// <summary>
		/// Добавить AutoMapper в службы приложения
		/// https://docs.automapper.org/en/stable/index.html
		/// </summary>
		/// <param name="services">Службы приложения</param>
		/// <returns>Службы приложения с AutoMapper</returns>
		public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services) =>
			services.AddAutoMapper(options => options
				.AddCore()
				.AddWeb());

		/// <summary>
		/// Добавить конфигурации автомаппера
		/// </summary>
		/// <param name="mapper">Билдер автомаппера</param>
		/// <returns>Билдер автомаппера с конфигурацией</returns>
		public static IMapperConfigurationExpression AddWeb(this IMapperConfigurationExpression mapper)
		{
			mapper.AddProfile(new MappingProfile());
			return mapper;
		}
	}
}
