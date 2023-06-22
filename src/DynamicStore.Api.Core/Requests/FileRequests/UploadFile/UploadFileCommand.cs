using System.Collections.Generic;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using MediatR;

namespace DynamicStore.Api.Core.Requests.FileRequests.UploadFile
{
	/// <summary>
	/// Запрос на сохранение файлов
	/// </summary>
	public class UploadFileCommand : UploadFileRequest, IRequest<UploadFileResponse>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public UploadFileCommand()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="files">Файлы для сохранения</param>
		/// <param name="uploadFileRequest">Дополнительные параметры запроса</param>
#pragma warning disable IDE0060 // Remove unused parameter
		public UploadFileCommand(IEnumerable<UploadFileRequestItem> files, UploadFileRequest uploadFileRequest)
#pragma warning restore IDE0060 // Remove unused parameter
			=> Files = files;

		/// <summary>
		/// Файлы для сохранения
		/// </summary>
		/// <remarks>
		/// Вызывать перечисление IEnumerable можно только 1 раз, т.к. в нем обрабатывается IFormFile[].
		/// Обрабатывать данные массива только последовательно, чтоб избежать The inner stream position has changed unexpectedly`
		/// (https://stackoverflow.com/questions/55674322/getting-the-inner-stream-position-has-changed-unexpectedly-in-aws-lambda).
		/// Поток с данными каждого файла закрывается перед считыванием следующего.
		/// </remarks>
		public IEnumerable<UploadFileRequestItem> Files { get; set; } = default!;
	}
}
