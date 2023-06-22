using System;

namespace DynamicStore.Api.Core.Services
{
	/// <summary>
	/// Сервис кодирования/декодирования base64.
	/// </summary>
	public static class Base64UrlEncoder
	{
		/// <summary>
		/// Закодировать.
		/// </summary>
		/// <param name="input">Данные.</param>
		/// <returns>Закодированная строка.</returns>
		public static string Encode(string input)
			=> input
				.Split('=')[0]
				.Replace('+', '-')
				.Replace('/', '_'); // 62nd and 63rd char of encoding

		/// <summary>
		/// Декодировать.
		/// </summary>
		/// <param name="input">Данные.</param>
		/// <returns>Декодированный массив байтов.</returns>
		public static byte[] Decode(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
				throw new ArgumentException($"\"{nameof(input)}\" не может быть пустым или содержать только пробел.", nameof(input));

			input = input.Replace('-', '+').Replace('_', '/'); // 62nd and 63rd char of encoding

			// Pad with trailing '='s
			switch (input.Length % 4)
			{
				case 0:
					break; // No pad chars in this case
				case 2:
					input += "==";
					break; // Two pad chars
				case 3:
					input += "=";
					break; // One pad char
				default:
					throw new ArgumentOutOfRangeException(
						nameof(input), "Illegal base64url string!");
			}

			return Convert.FromBase64String(input); // Standard base64 decoder
		}
	}
}
