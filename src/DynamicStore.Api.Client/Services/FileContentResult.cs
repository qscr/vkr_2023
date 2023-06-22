namespace DynamicStore.Api.Client.Services
{
	/// <summary>
	/// Файл с данными
	/// </summary>
	public class FileContentResult
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="fileContent">Данные файла</param>
		/// <param name="contentType">Тип файла</param>
		public FileContentResult(byte[] fileContent, string? contentType = null)
		{
			FileContents = fileContent;
			ContentType = contentType;
		}

		/// <summary>
		/// Данные файла
		/// </summary>
		public byte[] FileContents { get; set; } = default!;

		/// <summary>
		/// Тип файла
		/// </summary>
		public string? ContentType { get; set; }

		/// <summary>
		/// Название файла
		/// </summary>
		public string? FileDownloadName { get; internal set; }
	}
}
