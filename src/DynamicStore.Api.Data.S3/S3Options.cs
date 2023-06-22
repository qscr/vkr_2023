using System;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Конфигурация хранилища
	/// </summary>
	public class S3Options
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string AccessKey { get; set; } = default!;

		/// <summary>
		/// Секрет
		/// </summary>
		public string SecretKey { get; set; } = default!;

		/// <summary>
		/// УРЛ хранилища
		/// </summary>
		public string ServiceUrl { get; set; } = default!;

		/// <summary>
		/// Название бакета
		/// </summary>
		public string BucketName { get; set; } = default!;

		/// <summary>
		/// Игнорить проблемы с сертификатом в S3
		/// </summary>
		public bool IgnoreCertificateErrors { get; set; } = true;

		/// <summary>
		/// Таймаут
		/// </summary>
		public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(3);
	}
}
