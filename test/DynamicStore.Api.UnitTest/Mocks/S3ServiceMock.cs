using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Models;

namespace DynamicStore.Api.UnitTest.Mocks
{
	/// <summary>
	/// Мок S3-хранилища в памяти
	/// </summary>
	public class S3ServiceMock : Dictionary<string, FileContent>, IS3Service
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="options">Инициализация хранилища</param>
		public S3ServiceMock(Action<Dictionary<string, FileContent>> options = null)
			=> options?.Invoke(this);

		/// <inheritdoc/>
		public Task DeleteAsync(string key, string bucket = null, CancellationToken cancellationToken = default)
			=> Task.FromResult(Remove(key));

		/// <inheritdoc/>
		public Task<Stream> DownloadAsync(string key, string bucket = null, CancellationToken cancellationToken = default)
			=> Task.FromResult(ContainsKey(key) ? this[key]?.Content : null);

		/// <inheritdoc/>
		public Task<FileContent> GetAsync(string key, string bucket = null, CancellationToken cancellationToken = default)
			=> Task.FromResult(ContainsKey(key) ? this[key] : null);

		/// <inheritdoc/>
		public Task<List<string>> GetBucketsAsync(CancellationToken cancellationToken = default)
			=> Task.FromResult(new List<string> { "testbucket" });

		/// <inheritdoc/>
		public Task<string> UploadAsync(FileContent file, CancellationToken cancellationToken = default)
		{
			var key = Guid.NewGuid().ToString();
			Add(key, (FileContent)file.Clone());
			return Task.FromResult(key);
		}
	}
}
