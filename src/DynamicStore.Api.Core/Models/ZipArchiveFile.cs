using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicStore.Api.Core.Models
{
	/// <summary>
	/// Файл для архивации в zip
	/// </summary>
	public class ZipArchiveFile
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Название файла</param>
		/// <param name="body">Тело файла</param>
		public ZipArchiveFile(string name, byte[] body)
		{
			Name = name;
			Body = body;
		}

		/// <summary>
		/// Название файла
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Тело файла
		/// </summary>
		public byte[] Body { get; set; }

		/// <summary>
		/// Создать сущность с помощью Stream
		/// </summary>
		/// <param name="name">Название файла</param>
		/// <param name="content">Бинарные данные файла</param>
		/// <param name="cancellationToken">Токен отмены операции</param>
		/// <returns>Сущность</returns>
		public static async Task<ZipArchiveFile> CreateWithStreamAsync(string name, Stream content, CancellationToken cancellationToken = default)
		{
			var fileBody = await GetByteArrayFromStreamAsync(content, cancellationToken);
			return new(name, fileBody);
		}

		private static async Task<byte[]> GetByteArrayFromStreamAsync(Stream inputStream, CancellationToken cancellationToken = default)
		{
			using (var ms = new MemoryStream())
			{
				await inputStream.CopyToAsync(ms, cancellationToken);
				return ms.ToArray();
			}
		}
	}
}
