using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Models;

namespace DynamicStore.Api.Core.Services
{
	/// <inheritdoc/>
	public class ZipArchiver : IZipArchiver
	{
		private static readonly string[] ZipMimeTypes = new string[] { "application/zip", "application/x-zip-compressed" };

		/// <inheritdoc/>
		public bool IsZipArchive(string contentType) => ZipMimeTypes.Contains(contentType);

		/// <inheritdoc/>
		public async Task<byte[]> ZipAsync(IEnumerable<ZipArchiveFile> files, CancellationToken cancellationToken = default)
		{
			if (files == null)
				throw new ArgumentNullException(nameof(files));

			var totalLength = files.Sum(x => x.Body.Length);

			using var memoryStream = new MemoryStream(totalLength);
			using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
			{
				foreach (var file in files)
				{
					if (file?.Body == null)
						continue;

					var entry = zipArchive.CreateEntry(file.Name, CompressionLevel.Fastest);
					using (var entryStream = entry.Open())
					{
						await entryStream.WriteAsync(file.Body, cancellationToken);
					}
				}
			}
			return memoryStream.ToArray();
		}

		/// <inheritdoc/>
		public async Task<List<ZipArchiveFile>> UnzipAsync(Stream stream, CancellationToken cancellationToken = default)
		{
			var response = new List<ZipArchiveFile>();
			using (var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read, true))
			{
				foreach (var file in zipArchive.Entries)
				{
					using var body = file.Open();
					using (var ms = new MemoryStream())
					{
						await body.CopyToAsync(ms, cancellationToken);
						response.Add(new ZipArchiveFile(file.FullName, ms.ToArray()));
					}
				}
			}
			return response;
		}
	}
}
