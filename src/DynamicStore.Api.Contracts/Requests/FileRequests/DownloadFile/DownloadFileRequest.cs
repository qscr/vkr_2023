using System;

namespace DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile
{
	/// <summary>
	/// Запрос на получение списка машин
	/// </summary>
	public class DownloadFileRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">ИД файла</param>
		public DownloadFileRequest(Guid id) => Id = id;

		/// <summary>
		/// ИД файла
		/// </summary>
		public Guid Id { get; set; } = default!;
	}
}
