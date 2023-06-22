using System;
using System.Net.Http;
using DynamicStore.Api.Client.Services;
using DynamicStore.Api.Contracts.Services;
using DynamicStore.Api.Core.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using DynamicStore.Api.Data.PostgreSql;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Web;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Serilog;
using Serilog.Events;
using Xunit.Abstractions;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using DynamicStore.Api.Contracts.Requests.FileRequests.UploadFile;

namespace DynamicStore.Api.IntegrationTest
{
	/// <summary>
	/// Фабрика сервисов для интеграционного тестирования
	/// </summary>
	/// <typeparam name="TEntryPoint">Startup</typeparam>
	public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
	{
		/// <summary>
		/// БД
		/// </summary>
		private readonly TestInitializerFixture _testFixture;

		/// <summary>
		/// Логин и пароль для пользователя - администратора
		/// </summary>
		protected const string AdminLoginPassword = "TestLoginPassword";

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="testOutputHelper">Назначение для логов</param>
		/// <param name="testFixture">Инициализация контейнеров</param>
		public CustomWebApplicationFactory(
			ITestOutputHelper testOutputHelper,
			TestInitializerFixture testFixture)
		{
			ClientOptions.AllowAutoRedirect = false;

			DateTimeProvider = new Mock<IDateTimeProvider>();
			DateTimeProvider.Setup(x => x.UtcNow).Returns(new DateTime(2021, 5, 28));

			Log.Logger = new LoggerConfiguration()
				.WriteTo.Debug()
				.WriteTo.TestOutput(testOutputHelper, LogEventLevel.Verbose)
				.CreateLogger();

			PasswordEncryptionService = new Mock<IPasswordEncryptionService>();
			PasswordEncryptionService
				.Setup(x => x.ValidatePassword(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(true);
			PasswordEncryptionService
				.Setup(x => x.EncodePassword(It.IsAny<string>()))
				.Returns<string>(x => x);

			_testFixture = testFixture;
		}

		/// <summary>
		/// Провайдер даты и времени
		/// </summary>
		protected Mock<IDateTimeProvider> DateTimeProvider { get; private set; }


		/// <summary>
		/// Сервис хеширования паролей
		/// </summary>
		protected Mock<IPasswordEncryptionService> PasswordEncryptionService { get; private set; }

		/// <summary>
		/// Получить сущность из БД
		/// </summary>
		/// <typeparam name="TResult">Тип сущности</typeparam>
		/// <param name="condition">Условие</param>
		/// <returns>Сущность</returns>
		protected async Task<TResult> GetEntityAsync<TResult>(Expression<Func<TResult, bool>> condition = default)
			where TResult : EntityBase
		{
			using var scope = Services.CreateScope();
			using var context = scope.ServiceProvider.GetRequiredService<EfContext>();
			return await context.Set<TResult>().FirstOrDefaultAsync(condition ?? (x => true));
		}

		/// <summary>
		/// Сохранить файлы в S3 хранилище
		/// </summary>
		/// <param name="client">Клиент</param>
		/// <param name="metadata">Метаданные</param>
		/// <param name="files">Файлы</param>
		/// <returns>Ответ на запрос сохранения файлов</returns>
		protected async Task<UploadFileResponse> UploadFilesAsync(
			IMicroserviceClient client,
			UploadFileRequest metadata,
			params UploadFileRequestItem[] files)
			=> await client.UploadFileAsync(metadata ?? new UploadFileRequest(), files);

		/// <summary>
		/// Создать HTTP-клиента тест-сервиса с моками хранилищ в памяти
		/// </summary>
		/// <param name="dbSeeder">Инициализация БД</param>
		/// <returns>HTTP-клиент</returns>
		protected HttpClient CreateClient(Action<EfContext> dbSeeder = null)
		{
			var client = base.CreateClient();
			using var scope = Services.CreateScope();
			using var context = scope.ServiceProvider.GetRequiredService<EfContext>();
			context.Database.EnsureCreated();

			context.Users.Add(User.CreateForTest(
				email: AdminLoginPassword,
				passwordHash: AdminLoginPassword));

			dbSeeder?.Invoke(context);
			context.SaveChangesAsync().GetAwaiter().GetResult();

			return client;
		}

		/// <summary>
		/// Создать API-клиента тест-сервиса с моками хранилищ в памяти
		/// </summary>
		/// <param name="dbSeeder">Инициализация БД</param>
		/// <returns>Клиентская библиотека сервиса</returns>
		protected virtual IMicroserviceClient CreateApiClient(Action<EfContext> dbSeeder = null)
			=> new MicroserviceClient(CreateClient(dbSeeder));

		protected override void ConfigureWebHost(IWebHostBuilder builder)
			=> builder
			.ConfigureAppConfiguration((context, conf)
				=> conf
					.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
					.AddEnvironmentVariables()
					.AddInMemoryCollection(new List<KeyValuePair<string, string>>
					{
						// переопределение строки подключения для интеграционных тестов
						new KeyValuePair<string, string>("Application:DbConnectionString", _testFixture.DbConnectionString),
						new KeyValuePair<string, string>("Application:RmqConnectionString", _testFixture.RabbitConnectionString),
						new KeyValuePair<string, string>("Application:S3:AccessKey", _testFixture.S3options.AccessKey),
						new KeyValuePair<string, string>("Application:S3:SecretKey", _testFixture.S3options.SecretKey),
						new KeyValuePair<string, string>("Application:S3:ServiceUrl", _testFixture.S3options.ServiceUrl),
						new KeyValuePair<string, string>("Application:S3:BucketName", _testFixture.S3options.BucketName),
						new KeyValuePair<string, string>("Application:S3:IgnoreCertificateErrors", _testFixture.S3options.IgnoreCertificateErrors.ToString().ToLower()),
					}))
				.UseEnvironment("Test")
				.ConfigureTestServices(ConfigureServices);

		private void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<EfContext>(options =>
				options.UseNpgsql(_testFixture.DbConnectionString));
			services.AddTransient(x => PasswordEncryptionService.Object);
			services.AddTransient(x => DateTimeProvider.Object);
		}

		protected override void Dispose(bool disposing)
		{
			_testFixture.ClearDatabaseData();
			base.Dispose(disposing);
		}
	}
}
