using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests;
using DynamicStore.Api.Contracts.Requests.AuthenticationRequests.Login;
using DynamicStore.Api.Contracts.Requests.FileRequests.DownloadFile;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Contracts.Services;

namespace DynamicStore.Api.Client.Services
{
	/// <summary>
	/// Клиент микросервиса
	/// </summary>
	public class MicroserviceClient : HttpClientBase, IMicroserviceClient
	{
		/// <summary>
		/// Версия API
		/// </summary>
		public const string Version = "1.0";

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="httpClient">HTTP-клиент</param>
		public MicroserviceClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		/// <inheritdoc/>
		public async Task AuthorizeAsync(LoginRequest request)
		{
			var response = await PostAsync<TokenResponse>($"/api/v{Version}/Authentication/Login", request).ConfigureAwait(false);
			SetToken(response.Token!);
		}

		#region File

		/// <inheritdoc/>
		public async Task<UploadFileResponse?> UploadFileAsync(UploadFileRequest metadata, params UploadFileRequestItem[] files)
		{
			if (files is null)
				throw new ArgumentNullException(nameof(files));

			if (files?.Any(x => x.FileStream == null) == true)
				throw new ArgumentException("Переданы пустые файлы");

			if (files?.Any(x => string.IsNullOrWhiteSpace(x.ContentType)) == true)
				throw new ArgumentException("Переданы файлы без mime-типа");

			// наполнить content: content.Add(new StringContent(value?.ToString() ?? ""), "value");
			var content = new MultipartFormDataContent();

			foreach (var file in files!)
			{
				if (file.FileStream.Position != 0)
				{
					if (!file.FileStream.CanSeek)
						throw new ArgumentException("Переданы файлы со смещенной от 0 позицией в буфере");

					file.FileStream.Position = 0;
				}

				var fileContent = new StreamContent(file.FileStream, (int)file.FileStream.Length);
				fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
				content.Add(fileContent, "files", file.FileName);
			}

			return await PostAsync<UploadFileResponse>($"/api/v{Version}/File", content).ConfigureAwait(false);
		}

		/// <inheritdoc/>
		public async Task<DownloadFileResponse?> DownloadFileAsync(Guid id)
		{
			var result = await GetFileContentAsync($"/api/v{Version}/File/{id}/Download").ConfigureAwait(false);
			return result == null
				? null
				: new DownloadFileResponse(new MemoryStream(result.FileContents), result.ContentType, result.FileDownloadName);
		}

		#endregion
	}
}
