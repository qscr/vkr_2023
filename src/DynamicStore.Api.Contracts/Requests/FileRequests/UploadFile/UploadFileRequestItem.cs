using System.IO;

namespace DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile
{
	/// <summary>
	/// Файл для сохранения
	/// </summary>
	public class UploadFileRequestItem
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="fileStream">Прикрепленный файл</param>
		/// <param name="fileName">Имя файла</param>
		/// <param name="contentType">Тип содержимого/Mime-type</param>
		public UploadFileRequestItem(Stream fileStream, string fileName, string contentType)
		{
			FileStream = fileStream;
			FileName = fileName;
			ContentType = contentType;
		}

		public UploadFileRequestItem(byte[] fileBytes, string fileName, string contentType)
			: this(new MemoryStream(fileBytes ?? System.Array.Empty<byte>()), fileName, contentType)
		{
		}

		/// <summary>
		/// Прикрепленный файл
		/// </summary>
		public Stream FileStream { get; set; }

		/// <summary>
		/// Имя файла
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Тип содержимого/Mime-type
		/// </summary>
		public string ContentType { get; set; }
	}
}
