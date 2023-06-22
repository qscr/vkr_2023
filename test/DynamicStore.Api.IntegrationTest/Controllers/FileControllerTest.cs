using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Contracts.Services;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.IntegrationTest.Controllers
{
	/// <summary>
	/// Тестовые методы для контроллера машинок
	/// </summary>
	[Collection(nameof(TestCollectionFixture))]
	public class FileControllerTest : CustomWebApplicationFactory
	{
		private readonly IMicroserviceClient _client;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Лог для тестов</param>
		/// <param name="testInitializer">Инициализация контейнеров</param>
		public FileControllerTest(
			ITestOutputHelper testOutputHelper,
			TestInitializerFixture testInitializer)
			: base(testOutputHelper, testInitializer)
			=> _client = CreateApiClient();

		/// <summary>
		/// Метод скачивания файла по существующему ИД должен его найти и скачать
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task DownloadFileAsync_ExistingFileId_ShouldReturnFileAsync()
		{
			var uploadFileRequest = new UploadFileRequestItem(new MemoryStream(new byte[] { 1, 2, 3 }), "test.txt", "text/plain");
			var uploadResponses = await UploadFilesAsync(_client, default, uploadFileRequest);

			Assert.NotNull(uploadResponses);
			var uploadResponse = Assert.Single(uploadResponses.FileNameToFileId.Where(x => x.Key == uploadFileRequest.FileName));

			var response = await _client.DownloadFileAsync(uploadResponse.Value);

			Assert.NotNull(response);
			Assert.Equal(uploadFileRequest.ContentType, response.ContentType);
			Assert.Equal(uploadFileRequest.FileName, response.FileName);
			Assert.Equal(3, response.Content?.Length);
		}

		/// <summary>
		/// Метод скачивания файла по несуществующему ИД должен бросить исключение
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task DownloadFileAsync_FakeFileId_ShouldThrowNotFoundExceptionAsync()
			=> await Assert.ThrowsAsync<ClientException>(
				async () => await _client.DownloadFileAsync(Guid.NewGuid()));

		/// <summary>
		/// Метод загрузки файлов должен возвращать ИД-шники загружаемых файлов
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_MultipleValidFiles_ShouldReturnFileIdsAsync()
		{
			var files = new UploadFileRequestItem[]
			{
				new UploadFileRequestItem(new MemoryStream(new byte[]{ 1, 2, 3 }), "test.txt", "text/plain"),
				new UploadFileRequestItem(new MemoryStream(new byte[]{ 1, 2, 3, 4 }), "test1.txt", "image/png"),
			};
			var response = await UploadFilesAsync(_client, default, files);

			Assert.NotNull(response?.FileNameToFileId);
			Assert.Equal(files.Length, response.FileNameToFileId.Count);
			Assert.True(response.FileNameToFileId.Keys.All(fileName => files.Any(x => x.FileName == fileName)));
		}
	}
}
