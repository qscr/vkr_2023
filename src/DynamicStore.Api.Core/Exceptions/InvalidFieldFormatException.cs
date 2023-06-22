namespace DynamicStore.Api.Core.Exceptions
{
	/// <summary>
	/// Исключение "Неверный формат поля"
	/// </summary>
	public class InvalidFieldFormatException : ApplicationExceptionBase
	{
		/// <summary>
		/// Исключение "Неверный формат поля"
		/// </summary>
		/// <param name="field">Поле</param>
		public InvalidFieldFormatException(string field)
			: base($"Неверный формат поля {field}")
		{
		}
	}
}
