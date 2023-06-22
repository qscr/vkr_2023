using System;
using System.IO;

namespace DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile
{
	/// <summary>
	/// Ответ на запрос списка машин
	/// </summary>
	public class DownloadFileResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="content">Данные файла</param>
		/// <param name="contentType">Тип файла</param>
		/// <param name="fileName">Название</param>
		public DownloadFileResponse(Stream content, string? contentType, string? fileName)
		{
			Content = content ?? throw new ArgumentNullException(nameof(content));
			FileName = fileName ?? throw new ArgumentNullException(nameof(content));
			ContentType = contentType;
		}

		/// <summary>
		/// Данные файла
		/// </summary>
		public Stream Content { get; set; } = default!;

		/// <summary>
		/// Тип файла
		/// </summary>
		public string? ContentType { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string FileName { get; set; } = default!;
	}
}
