using System;
using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Api.Core.Validators
{
	/// <summary>
	/// Валидатор почты
	/// </summary>
	public static class EmailValidator
	{
		/// <summary>
		/// Проверяет строку на соответствие почтовому адресу
		/// </summary>
		/// <param name="email">Строка для проверки</param>
		/// <param name="requiredDotInDomainName">Требуется проверить точку в домене почты</param>
		/// <returns>Соответствует ли строка почтовому адресу</returns>
		public static bool IsValidEmailAddress(string? email, bool requiredDotInDomainName = false)
		{
			if (email is null)
				return false;

			var isValid = new EmailAddressAttribute().IsValid(email);

			if (!isValid || !requiredDotInDomainName)
				return isValid;

			var arr = email.Split('@', StringSplitOptions.RemoveEmptyEntries);

			return arr.Length == 2 && arr[1].Contains('.');
		}
	}
}
