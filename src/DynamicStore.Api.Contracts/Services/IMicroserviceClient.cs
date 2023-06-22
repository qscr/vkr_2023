using System;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Login;
using DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;

namespace DynamicStore.Api.Contracts.Services
{
	/// <summary>
	/// Клиент микросервиса
	/// <exception cref="ClientException"/>
	/// </summary>
	public interface IMicroserviceClient
	{
		/// <summary>
		/// Авторизоваться в системе
		/// </summary>
		/// <param name="request">Запрос</param>
		/// <returns>-</returns>
		Task AuthorizeAsync(LoginRequest request);

		#region File

		/// <summary>
		/// Загрузить файлы
		/// </summary>
		/// <param name="metadata">Метаданные сохраняемых файлов</param>
		/// <param name="files">Файлы</param>
		/// <returns>Список машин</returns>
		Task<UploadFileResponse?> UploadFileAsync(UploadFileRequest metadata, params UploadFileRequestItem[] files);

		/// <summary>
		/// Скачать файл по его ИД
		/// </summary>
		/// <param name="id">ИД файла</param>
		/// <returns>Данные файла</returns>
		Task<DownloadFileResponse?> DownloadFileAsync(Guid id);

		#endregion
	}
}
