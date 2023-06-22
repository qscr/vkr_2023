using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Core.Requests.FileRequests.DownloadFile;
using DynamicStore.Api.Core.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Web.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using DynamicStore.Api.Contracts.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace DynamicStore.Api.Web.Controllers
{
	/// <summary>
	/// Контроллер файлов
	/// </summary>
	[ApiVersion(ApiVersions.V1)]
	[RequestSizeLimit(100000000)]
	public class FileController : ApiControllerBase
	{
		private const string DefaultContentType = "application/octet-stream";

		/// <summary>
		/// Загрузить файлы в хранилище
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="files">Файлы для загрузки</param>
		/// <param name="request">Дополнительные данные запроса на сохранение файлов</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <returns>Список ключей загруженных файлов</returns>
		[HttpPost]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(UploadFileResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		public async Task<UploadFileResponse> UploadAsync(
			[FromServices] IMediator mediator,
			[FromForm] List<IFormFile> files,
			[FromForm] UploadFileRequest request,
			CancellationToken cancellationToken)
			=> await mediator.Send(new UploadFileCommand(GetFilesEnumerable(files), request), cancellationToken);

		/// <summary>
		/// Скачать файл из хранилища
		/// </summary>
		/// <param name="mediator">Медиатор CQRS</param>
		/// <param name="id">ИД файла для скачивания</param>
		/// <param name="cancellationToken">Токен отмены запроса</param>
		/// <param name="inline">Если TRUE, то заголово ответа Content-Disposition=inline, иначе attachment</param>
		/// <returns>Список ключей загруженных файлов</returns>
		[HttpGet("{id}/Download")]
		[SwaggerResponse(StatusCodes.Status200OK, type: typeof(UploadFileResponse))]
		[SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ProblemDetailsResponse))]
		[SwaggerResponse(StatusCodes.Status404NotFound, type: typeof(ProblemDetailsResponse))]
		public async Task<FileStreamResult> DownloadAsync(
			[FromServices] IMediator mediator,
			[FromRoute] Guid id,
			CancellationToken cancellationToken,
			[FromQuery] bool inline = false)
		{
			var file = await mediator.Send(new DownloadFileQuery(id), cancellationToken);

			var cd = new ContentDispositionHeaderValue(inline ? "inline" : "attachment");
			cd.SetHttpFileName(file.FileName);
			Response.Headers[HeaderNames.ContentDisposition] = cd.ToString();

			return new FileStreamResult(file.Content, file.ContentType ?? DefaultContentType);
		}

		/// <summary>
		/// Получить файлы для дальнейшего сохранения в хранилище
		/// </summary>
		/// <remarks>
		/// Метод реализован через IEnumerable, потому что OpenReadStream() необходимо вызывать последовательно
		/// </remarks>
		/// <returns>Список файлов</returns>
		private static IEnumerable<UploadFileRequestItem> GetFilesEnumerable(List<IFormFile> formFiles)
		{
			foreach (var file in formFiles ?? new List<IFormFile>())
			{
				using var stream = file.OpenReadStream();
				yield return new UploadFileRequestItem(stream, file.FileName, file.ContentType);
			}
		}
	}
}
