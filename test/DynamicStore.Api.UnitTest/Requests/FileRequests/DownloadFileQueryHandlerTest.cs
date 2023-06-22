using System;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using DynamicStore.Api.Core.Models;
using DynamicStore.Api.Core.Requests.FileRequests.DownloadFile;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest.Requests.FileRequests
{
	/// <summary>
	/// Тест <see cref="DownloadFileQuery"/>
	/// </summary>
	public class DownloadFileQueryHandlerTest : UnitTestBase
	{
		private readonly IDbContext _dbContext;
		private readonly IS3Service _s3Service;
		private readonly File _fileWithContent;
		private readonly File _fileWithoutContent;
		private readonly FileContent _fileContent;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Логгер</param>
		public DownloadFileQueryHandlerTest(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{
			_fileWithoutContent = File.CreateForTest("s3notexists", "text2.txt", 1000, "image/jpg");
			_fileWithContent = File.CreateForTest("s3", "text.txt", 3, "text/plain");
			_fileContent = FileContent.CreateForTest(new byte[] { 1, 2, 3 }, "text.txt", "text/plain");
			_dbContext = CreateInMemoryContext(x => x.AddRange(_fileWithContent, _fileWithoutContent));
			_s3Service = CreateInMemoryS3Service(x => x.Add(_fileWithContent.Address, _fileContent));
		}

		/// <summary>
		/// Метод скачивания файла по существующему ИД должен его найти и скачать
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_ExistingFileId_ShouldReturnFileAsync()
		{
			var request = new DownloadFileQuery(_fileWithContent.Id);
			var handler = new DownloadFileQueryHandler(_s3Service, _dbContext);
			var response = await handler.Handle(request, default);

			Assert.NotNull(response);
			Assert.Equal(_fileWithContent.ContentType, response.ContentType);
			Assert.Equal(_fileWithContent.FileName, response.FileName);
			Assert.Equal(_fileWithContent.Size, response.Content?.Length);
			Assert.Equal(_fileContent.Content?.Length, response.Content?.Length);
		}

		/// <summary>
		/// Метод скачивания файла по несуществующему ИД должен бросить исключение
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_FakeFileId_ShouldThrowNotFoundExceptionAsync()
		{
			var request = new DownloadFileQuery(Guid.NewGuid());
			var handler = new DownloadFileQueryHandler(_s3Service, _dbContext);

			await Assert.ThrowsAsync<EntityNotFoundException<File>>(
				async () => await handler.Handle(request, default));
		}

		/// <summary>
		/// Метод скачивания файла, у которого нет контента в S3-хранилище, должен бросить исключение
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_FileWithoutContentInS3_ShouldThrowNotFoundExceptionAsync()
		{
			var request = new DownloadFileQuery(_fileWithoutContent.Id);
			var handler = new DownloadFileQueryHandler(_s3Service, _dbContext);

			await Assert.ThrowsAsync<EntityNotFoundException<File>>(
				async () => await handler.Handle(request, default));
		}
	}
}
