using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Exceptions;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.IntegrationTest
{
	/// <summary>
	/// Тесты на healthcheck'и
	/// </summary>
	[Collection(nameof(TestCollectionFixture))]
	public class HealthCheckTest : CustomWebApplicationFactory
	{
		private readonly HttpClient _client;

		/// <summary>
		/// Контроллер
		/// </summary>
		/// <param name="testOutputHelper">Тестовый логгер</param>
		/// <param name="testInitializer">БД</param>
		public HealthCheckTest(
			ITestOutputHelper testOutputHelper,
			TestInitializerFixture testInitializer)
			: base(testOutputHelper, testInitializer)
			=> _client = CreateClient();

		/// <summary>
		/// Хелсчек по умолчанию должен вернуть 200
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task GetStatusAllServices_Default_Returns200OkAsync()
		{
			var health = "/health";
			// RabbitMq стартует асинхронно, добавляем ожидание таким образом
			for (var attempt = 1; attempt <= 3; attempt++)
			{
				var response = await _client.GetAsync(new Uri(health, UriKind.Relative)).ConfigureAwait(false);

				if (response.StatusCode != HttpStatusCode.OK)
				{
					await Task.Delay(5000);
					continue;
				}

				return;
			}

			throw new ApplicationExceptionBase(health);
		}

		/// <summary>
		/// Хелсчек внутренний по умолчанию должен вернуть 200
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task GetStatusSelf_Default_Returns200OkAsync()
		{
			var response = await _client.GetAsync(new Uri("/health/live", UriKind.Relative)).ConfigureAwait(false);
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}
