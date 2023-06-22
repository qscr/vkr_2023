using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile
{
	/// <summary>
	/// Ответ на запрос сохранения файлов
	/// </summary>
	public class UploadFileResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public UploadFileResponse()
			=> FileNameToFileId = new Dictionary<string, Guid>();

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="fileNameToKeys">Словарь {название файла=ид сохраненного файла}</param>
		public UploadFileResponse(Dictionary<string, Guid> fileNameToKeys)
			=> FileNameToFileId = fileNameToKeys;

		/// <summary>
		/// Словарь {название файла=ид сохраненного файла}
		/// </summary>
		public Dictionary<string, Guid> FileNameToFileId { get; set; } = default!;
	}
}
