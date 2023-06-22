using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Web;
using DynamicStore.Api.Client.Converters;
using DynamicStore.Api.Contracts.Services;

namespace DynamicStore.Api.Client.Services
{
	/// <summary>
	/// Базовый клиент HTTP
	/// </summary>
	public partial class HttpClientBase
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _options;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="httpClient">HTTP-клиент</param>
		protected HttpClientBase(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_options = InitSerializationOptions();
		}

		/// <summary>
		/// Сформировать query string по полям объекта
		/// </summary>
		/// <param name="data">Объект</param>
		/// <returns>query string</returns>
		protected static string GetQueryString(object? data)
		{
			if (data == null)
				return string.Empty;

			var properties = from p in data.GetType().GetProperties()
							 where p.GetValue(data, null) != null
							 select $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(data, null)?.ToString())}";

			return string.Join("&", properties.ToArray());
		}

		/// <summary>
		/// Сформировать query string по ассоциативному массиву
		/// </summary>
		/// <param name="data">Массив</param>
		/// <returns>query string</returns>
		protected static string GetQueryString(Dictionary<string, string> data)
		{
			if (data is null || !data.Any())
				return string.Empty;

			var properties = from key in data.Keys
							 where data[key] != null
							 select $"{key}={HttpUtility.UrlEncode(data[key].ToString())}";

			return string.Join("&", properties.ToArray());
		}

		/// <summary>
		/// Установить токен
		/// </summary>
		/// <param name="token">Токен</param>
		protected void SetToken(string token)
			=> _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

		/// <summary>
		/// GET
		/// </summary>
		/// <typeparam name="TResponse">Тип ответа</typeparam>
		/// <param name="url">url</param>
		/// <param name="data">query string</param>
		/// <exception cref="ClientException"/>
		/// <returns>Ответ</returns>
		protected virtual async Task<TResponse> GetAsync<TResponse>(string url, object? data = null)
			where TResponse : new()
		{
			var parameters = GetQueryString(data);
			parameters = !string.IsNullOrEmpty(parameters) ? $"?{parameters}" : parameters;
			var responseMessage = await _httpClient.GetAsync($"{url}{parameters}").ConfigureAwait(false);

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			return await ExtractJsonDataAsync<TResponse>(responseMessage).ConfigureAwait(false);
		}

		/// <summary>
		/// POST
		/// </summary>
		/// <typeparam name="TResponse">Тип ответа</typeparam>
		/// <param name="url">url</param>
		/// <param name="data">Тело</param>
		/// <exception cref="ClientException"/>
		/// <returns>Ответ</returns>
		protected virtual async Task<TResponse> PostAsync<TResponse>(string url, object data)
		{
			var responseMessage = await _httpClient.PostAsync(url, GetJsonContent(data)).ConfigureAwait(false);

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			return await ExtractJsonDataAsync<TResponse>(responseMessage).ConfigureAwait(false);
		}

		/// <summary>
		/// POST
		/// </summary>
		/// <typeparam name="TResponse">Тип ответа</typeparam>
		/// <param name="url">url</param>
		/// <param name="data">Тело</param>
		/// <exception cref="ClientException"/>
		/// <returns>Ответ</returns>
		protected virtual async Task<TResponse?> PostAsync<TResponse>(string url, HttpContent data)
			where TResponse : new()
		{
			var responseMessage = await _httpClient.PostAsync(url, data).ConfigureAwait(false);

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			return await ExtractJsonDataAsync<TResponse>(responseMessage).ConfigureAwait(false);
		}

		/// <summary>
		/// PUT
		/// </summary>
		/// <typeparam name="TResponse">Тип ответа</typeparam>
		/// <param name="url">url</param>
		/// <param name="data">Тело</param>
		/// <exception cref="ClientException"/>
		/// <returns>Ответ</returns>
		protected virtual async Task<TResponse?> PutAsync<TResponse>(string url, object data)
		{
			var responseMessage = await _httpClient.PutAsync(url, GetJsonContent(data)).ConfigureAwait(false);

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			return await ExtractJsonDataAsync<TResponse>(responseMessage).ConfigureAwait(false);
		}

		/// <summary>
		/// DELETE
		/// </summary>
		/// <typeparam name="TResponse">Тип ответа</typeparam>
		/// <param name="url">url</param>
		/// <param name="data">query string</param>
		/// <exception cref="ClientException"/>
		/// <returns>Ответ</returns>
		protected virtual async Task<TResponse?> DeleteAsync<TResponse>(string url, object? data = null)
		{
			var responseMessage = await _httpClient.DeleteAsync($"{url}?{GetQueryString(data)}").ConfigureAwait(false);

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			return await ExtractJsonDataAsync<TResponse>(responseMessage).ConfigureAwait(false);
		}

		/// <summary>
		/// GET FileContentResult
		/// </summary>
		/// <param name="url">url</param>
		/// <param name="data">query string</param>
		/// <returns>Ответ</returns>
		protected virtual async Task<FileContentResult> GetFileContentAsync(string url, object? data = null)
		{
			var paramsString = data != null ? $"?{GetQueryString(data)}" : string.Empty;
			var responseMessage = await _httpClient.GetAsync($"{url}{paramsString}");

			if (!responseMessage.IsSuccessStatusCode)
				await HandleUnsuccessfullResponseAsync(responseMessage).ConfigureAwait(false);

			var content = new FileContentResult(
				await responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false),
				responseMessage.Content.Headers.ContentType?.MediaType)
			{
				FileDownloadName = responseMessage.Content.Headers.ContentDisposition?.FileNameStar ??
					responseMessage.Content.Headers.ContentDisposition?.FileName,
			};
			return content;
		}

		private static JsonSerializerOptions InitSerializationOptions()
		{
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.Cyrillic, UnicodeRanges.BasicLatin),
			};
			options.Converters.Add(new JsonDocumentConverter());
			options.Converters.Add(new DateTimeConverter());
			options.Converters.Add(new JsonStringEnumConverter());

			options.PropertyNameCaseInsensitive = true;
			return options;
		}

		private async Task<TResponse> ExtractJsonDataAsync<TResponse>(HttpResponseMessage responseMessage)
		{
			if (responseMessage?.Content is null)
				return default!;

			var responseStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
			if (responseStream is null)
				return default!;

			return (await JsonSerializer.DeserializeAsync<TResponse>(responseStream, _options).ConfigureAwait(false))!;
		}

		private StringContent GetJsonContent(object data)
			=> new(JsonSerializer.Serialize(data, _options), Encoding.UTF8, "application/json");

		/// <summary>
		/// Обработка исключения для ответа с ошибочным статусом
		/// </summary>
		/// <param name="responseMessage">Ответ сервера</param>
		/// <exception cref="ClientException"/>
		/// <returns>-</returns>
		private async Task HandleUnsuccessfullResponseAsync(HttpResponseMessage responseMessage)
		{
			try
			{
				var details = await ExtractJsonDataAsync<ProblemDetailsResponse>(responseMessage).ConfigureAwait(false);
				var message = details?.Title ?? details?.Detail ?? "Ошибка при обработке запроса";
				throw new ClientException(message, responseMessage);
			}
			catch (JsonException)
			{
				var responseText = await responseMessage.Content.ReadAsStringAsync();
				throw new ClientException($"Произошло неожиданное исключение: {responseText}", responseMessage);
			}
		}
	}
}
