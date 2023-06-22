using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Requests.FileRequests.UploadFile;
using Xunit;
using Xunit.Abstractions;

namespace DynamicStore.Api.UnitTest.Requests.FileRequests
{
	/// <summary>
	/// Тест <see cref="UploadFileCommand"/>
	/// </summary>
	public class UploadFileCommandHandlerTest : UnitTestBase
	{
		private readonly IDbContext _dbContext;
		private readonly IS3Service _s3Service;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Логгер</param>
		public UploadFileCommandHandlerTest(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{
			_dbContext = CreateInMemoryContext();
			_s3Service = CreateInMemoryS3Service();
		}

		/// <summary>
		/// Метод загрузки файлов должен загружать файлы в БД и S3
		/// </summary>
		/// <returns>-</returns>
		[Fact]
		public async Task Handle_MultipleValidFiles_ShouldCreateFilesAsync()
		{
			var request = new UploadFileCommand()
			{
				Files = new List<UploadFileRequestItem>
				{
					new UploadFileRequestItem(new MemoryStream(new byte[]{ 1, 2, 3 }), "test.txt", "text/plain"),
					new UploadFileRequestItem(new MemoryStream(new byte[]{ 1, 2, 3, 4 }), "test1.txt", "image/png"),
				}
			};
			var handler = new UploadFileCommandHandler(_s3Service, _dbContext);
			var response = await handler.Handle(request, default);

			Assert.NotNull(response?.FileNameToFileId);
			Assert.Equal(request.Files.Count(), response.FileNameToFileId.Count);

			foreach (var responseFile in response.FileNameToFileId)
			{
				var requestFile = request.Files.FirstOrDefault(x => x.FileName == responseFile.Key);
				Assert.NotNull(requestFile);

				var dbFile = _dbContext.Files.FirstOrDefault(x => x.Id == responseFile.Value);
				Assert.NotNull(dbFile);
				Assert.Equal(requestFile.ContentType, dbFile.ContentType);
				Assert.Equal(requestFile.FileName, dbFile.FileName);
				Assert.Equal(requestFile.FileStream.Length, dbFile.Size);

				var s3File = await _s3Service.GetAsync(dbFile.Address);
				Assert.NotNull(s3File);
				Assert.Equal(requestFile.ContentType, s3File.ContentType);
				Assert.Equal(requestFile.FileName, s3File.FileName);
				Assert.Equal(requestFile.FileStream.Length, s3File.Content?.Length);
			}
		}
	}
}
