using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Models;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Сервис архивации в zip
	/// </summary>
	public interface IZipArchiver
	{
		/// <summary>
		/// Является ли зип-архивом
		/// </summary>
		/// <param name="contentType">Тип файла</param>
		/// <returns>ЗИП или не ЗИП</returns>
		bool IsZipArchive(string contentType);

		/// <summary>
		/// Заархивировать файлы
		/// </summary>
		/// <param name="files">Файлы</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Архив</returns>
		Task<byte[]> ZipAsync(IEnumerable<ZipArchiveFile> files, CancellationToken cancellationToken = default);

		/// <summary>
		/// Разархивировать файлы
		/// </summary>
		/// <param name="stream">Поток с архивом</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Файлы</returns>
		Task<List<ZipArchiveFile>> UnzipAsync(Stream stream, CancellationToken cancellationToken = default);
	}
}
