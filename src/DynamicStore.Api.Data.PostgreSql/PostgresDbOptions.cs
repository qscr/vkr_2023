using Microsoft.Extensions.Logging;

namespace DynamicStore.Api.Data.PostgreSql
{
	/// <summary>
	/// Конфиг проекта
	/// </summary>
	public class PostgresDbOptions
	{
		/// <summary>
		/// Строка подключения к БД
		/// </summary>
		public string ConnectionString { get; set; } = default!;

		/// <summary>
		/// Фабрика логгера для команд SQL
		/// </summary>
		public ILoggerFactory? SqlLoggerFactory { get; set; }
	}
}
