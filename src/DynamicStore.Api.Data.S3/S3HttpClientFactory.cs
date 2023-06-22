using System.Net.Http;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Фабрика http-клиентов для взаимодействия с хранилищем
	/// </summary>
	public class S3HttpClientFactory : Amazon.Runtime.HttpClientFactory
	{
		private readonly HttpClient _httpClient;

		public S3HttpClientFactory(HttpClient httpClient)
			=> _httpClient = httpClient;

		public override HttpClient CreateHttpClient(Amazon.Runtime.IClientConfig clientConfig) => _httpClient;
	}
}
