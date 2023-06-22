using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Models;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;

namespace DynamicStore.Api.Data.S3
{
	/// <summary>
	/// Сервис для взаимодействия с S3-хранилищем
	/// </summary>
	public class S3Service : IS3Service
	{
		/// <summary>
		/// Тип данных файла по умолчанию
		/// </summary>
		private const string DefaultContentType = "application/octet-stream";

		/// <summary>
		/// Поле метаданных для Названия файла
		/// </summary>
		private const string FilenameMetadataField = "x-amz-meta-filename";

		private readonly IAmazonS3 _client;
		private readonly S3Options _s3Options;
		private readonly ILogger<S3Service> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="client">Клиент от AWS S3</param>
		/// <param name="factory">Фабрика Http для обертки запросов</param>
		/// <param name="s3Options">Опции подключения к S3</param>
		/// <param name="logger">Логгер</param>
		public S3Service(IAmazonS3 client, S3HttpClientFactory factory, S3Options s3Options, ILogger<S3Service> logger)
		{
			_client = client;
			_s3Options = s3Options;
			_logger = logger;
			var amazonS3Config = (AmazonS3Config)_client.Config;
			amazonS3Config.HttpClientFactory = factory;
			amazonS3Config.ForcePathStyle = true;
		}

		/// <inheritdoc/>
		public async Task<string> UploadAsync(
			FileContent file,
			CancellationToken cancellationToken = default)
		{
			if (file?.Content == null)
				throw new ArgumentNullException(nameof(file));
			if (file?.FileName == null)
				throw new ArgumentException(nameof(file.FileName));

			var putRequest = new PutObjectRequest
			{
				BucketName = string.IsNullOrWhiteSpace(file.Bucket) ? _s3Options.BucketName : file.Bucket,
				Key = ContentKey(file.FileName),
				InputStream = file.Content,
				ContentType = string.IsNullOrWhiteSpace(file.ContentType) ? DefaultContentType : file.ContentType,
			};

			if (file.Metadata != null)
				foreach (var tag in file.Metadata.Keys)
					putRequest.Metadata.Add(tag, file.Metadata[tag]);

			putRequest.Metadata.Add(FilenameMetadataField, Uri.EscapeDataString(file.FileName));
			await _client.PutObjectAsync(putRequest, cancellationToken);
			return putRequest.Key;
		}

		/// <inheritdoc/>
		public async Task<FileContent?> GetAsync(
			string key,
			string? bucket = null,
			CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			if (string.IsNullOrWhiteSpace(bucket))
				bucket = _s3Options.BucketName;

			var request = new GetObjectRequest
			{
				BucketName = bucket,
				Key = key,
			};

			try
			{
				var response = await _client.GetObjectAsync(request, cancellationToken);

				if (response?.ResponseStream == null)
					return null;

				return new FileContent(
					response.ResponseStream,
					response.Metadata?.Keys?.Contains(FilenameMetadataField) == true
						? Uri.UnescapeDataString(response.Metadata[FilenameMetadataField])
						: "unnamed",
					response.Headers?.ContentType ?? DefaultContentType,
					response.BucketName,
					response.Metadata?.Keys?.ToDictionary(x => x, x => response.Metadata[x]));
			}
			catch (AmazonServiceException ex)
			{
				if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					_logger.LogWarning("Не найден файл {key} в бакете {bucket}", key, bucket);
					return null;
				}

				throw;
			}
		}

		/// <inheritdoc/>
		public async Task<Stream?> DownloadAsync(
			string key,
			string? bucket = null,
			CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			if (string.IsNullOrWhiteSpace(bucket))
				bucket = _s3Options.BucketName;

			try
			{
				return await _client.GetObjectStreamAsync(bucket, key, null, cancellationToken);
			}
			catch (AmazonServiceException ex)
			{
				if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					_logger.LogWarning("Не найден файл {key} в бакете {bucket}", key, bucket);
					return null;
				}

				throw;
			}
		}

		/// <inheritdoc/>
		public async Task DeleteAsync(
			string key,
			string? bucket = null,
			CancellationToken cancellationToken = default)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException(nameof(key));

			if (string.IsNullOrWhiteSpace(bucket))
				bucket = _s3Options.BucketName;

			var request = new DeleteObjectRequest
			{
				BucketName = bucket,
				Key = key,
			};
			await _client.DeleteObjectAsync(request, cancellationToken);
		}

		/// <inheritdoc/>
		public async Task<List<string>> GetBucketsAsync(CancellationToken cancellationToken = default)
		{
			var request = new ListBucketsRequest();
			var response = await _client.ListBucketsAsync(request, cancellationToken);
			return response?.Buckets?.Select(x => x.BucketName).ToList() ?? new List<string>();
		}

		private static string ContentKey(string? fileName)
			=> $"{DateTime.UtcNow:yyyy-MM-dd}/{Guid.NewGuid()}{Path.GetExtension(fileName)}";
	}
}
