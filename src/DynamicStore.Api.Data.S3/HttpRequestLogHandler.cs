using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Обработчик запросов в хранилище с логом
	/// </summary>
	public class HttpRequestLogHandler : DelegatingHandler
	{
		private readonly ILogger<HttpRequestLogHandler> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="logger">Логгер</param>
		public HttpRequestLogHandler(ILogger<HttpRequestLogHandler> logger)
			=> _logger = logger;

		/// <inheritdoc/>
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var requestLogData = (request.Method, request.RequestUri);
			_logger.LogInformation("AwsS3 request {method}", requestLogData);
			var response = await base.SendAsync(request, cancellationToken);
			_logger.LogInformation("AwsS3 response {response} {request}", (response.StatusCode, response.ReasonPhrase), requestLogData);
			return response;
		}
	}
}
