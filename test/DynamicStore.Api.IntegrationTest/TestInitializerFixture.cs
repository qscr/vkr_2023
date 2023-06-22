using System;
using System.IO;
using DynamicStore.Api.Data.S3;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RabbitMQ.Client;
using Respawn;

namespace DynamicStore.Api.IntegrationTest
{
	/// <summary>
	/// Инициализация контейнеров для теста
	/// </summary>
	public class TestInitializerFixture : IDisposable
	{
		private readonly int _databaseTestPort = 8100;
		private readonly int _rabbitmqTestPort = 8101;
		private readonly int _minioPort = 8866;
		private readonly int _minioLogPort = 8867;

		/// <summary>
		/// Чекпоинт
		/// </summary>
		private readonly Checkpoint _checkpoint;

		/// <summary>
		/// Docker-контейнеры
		/// </summary>
		private readonly ICompositeService _container;

		/// <summary>
		/// конструктор
		/// </summary>
		public TestInitializerFixture()
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.Build();

			var dbName = $"DynamicStore.Api.IntegrationTesting_{Guid.NewGuid()}".Replace("-", "_");

			// подключение к инициализирующей БД создается без БД
			var initialDbConnectionString = config["Application:DbConnectionString"]
				?? throw new InvalidOperationException("Не задана строка подключения к БД");
			var dbConnection = new NpgsqlConnectionStringBuilder(initialDbConnectionString)
			{
				Database = dbName,
				Host = "localhost",
				Port = _databaseTestPort,
			};
			DbConnectionString = dbConnection.ToString();

			var initialRabbitConnectionString = config["Application:RmqConnectionString"]
				?? throw new InvalidOperationException("Не задана строка подключения к RabbitMq");
			var uriBuilder = new UriBuilder(initialRabbitConnectionString)
			{
				Port = _rabbitmqTestPort
			};
			var rabbitConnection = new ConnectionFactory
			{
				Uri = uriBuilder.Uri,
			};
			RabbitConnectionString = rabbitConnection.Uri.ToString();

			S3options = new S3Options
			{
				AccessKey = "test",
				SecretKey = "test-at least 8 characters",
				ServiceUrl = $"http://localhost:{_minioPort}",
				BucketName = "integrationtests",
				IgnoreCertificateErrors = true,
			};

			var dockerComposeFile = Path.Combine(Directory.GetCurrentDirectory(), "docker-compose.yml");

			_container = new Ductus.FluentDocker.Builders.Builder()
				.UseContainer()
				.UseCompose()
				.FromFile(dockerComposeFile)
				.ServiceName("DynamicStore.Api.IntegrationTests")
				.WithEnvironment(
					"teststart=teststart",
					$"POSTGRESUSER={dbConnection.Username}",
					$"POSTGRESPASSWORD={dbConnection.Password}",
					$"POSTGRESPORT={dbConnection.Port}",
					$"RABBITMQPORT={rabbitConnection.Port}",
					$"RABBITMQPASSWORD={rabbitConnection.Password}",
					$"RABBITMQUSER={rabbitConnection.UserName}",
					$"RABBITMQVHOST={rabbitConnection.VirtualHost}",
					$"MINIOPORT={_minioPort}",
					$"MINIOLOGPORT1={_minioLogPort}",
					$"MINIOLOGPORT2={_minioLogPort}",
					$"MINIOLOGPORT3={_minioLogPort}",
					$"MINIOROOTUSER={S3options.AccessKey}",
					$"MINIOROOTPASSWORD={S3options.SecretKey}",
					$"MINIOBUCKETNAME={S3options.BucketName}",
					"testend=testend")
				.ForceRecreate()
				.Build()
				.Start();

			_checkpoint = new Checkpoint
			{
				DbAdapter = DbAdapter.Postgres,
				SchemasToInclude = new[] { "public" },
			};
		}

		/// <summary>
		/// Подключение к тестовой БД
		/// </summary>
		public string DbConnectionString { get; }

		/// <summary>
		/// Подключение к тестовому RabbitMq
		/// </summary>
		public string RabbitConnectionString { get; }

		public S3Options S3options { get; }

		/// <summary>
		/// Очистить ресурсы - удалить контейнеры
		/// </summary>
		public void Dispose()
		{
			try
			{
				_container.Dispose();
			}
			finally
			{
				GC.SuppressFinalize(this);
			}
		}

		/// <summary>
		/// Очистить все таблицы в тестовой БД
		/// </summary>
		public void ClearDatabaseData()
		{
			using var connection = new NpgsqlConnection(DbConnectionString);
			connection.Open();
			_checkpoint.Reset(connection).GetAwaiter().GetResult();
		}
	}
}
