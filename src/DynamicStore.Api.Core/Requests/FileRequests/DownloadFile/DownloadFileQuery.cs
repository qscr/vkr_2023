using System;
using DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile;
using MediatR;

namespace DynamicStore.Api.Core.Requests.FileRequests.DownloadFile
{
	/// <summary>
	/// Запрос на сохранение файлов
	/// </summary>
	public class DownloadFileQuery : DownloadFileRequest, IRequest<DownloadFileResponse>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">ИД файла</param>
		public DownloadFileQuery(Guid id)
			: base(id)
		{
		}
	}
}
