using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamicStore.Api.Core.Models
{
	/// <summary>
	/// Данные о файле
	/// </summary>
	public class FileContent : ICloneable
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public FileContent()
		{
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="content">Бинарные данные файла</param>
		/// <param name="fileName">Название файла</param>
		/// <param name="contentType">Тип данных файла</param>
		/// <param name="bucket">Бакет, в который сохраняется файл</param>
		/// <param name="metadata">Метаданные файла</param>
		public FileContent(
			Stream content,
			string fileName,
			string? contentType = null,
			string? bucket = null,
			IDictionary<string, string>? metadata = null)
		{
			FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
			Content = content ?? throw new ArgumentNullException(nameof(content));
			ContentType = contentType;
			Bucket = bucket;
			Metadata = metadata;
		}

		/// <summary>
		/// Бинарные данные файла
		/// </summary>
		public Stream Content { get; set; } = default!;

		/// <summary>
		/// Название файла
		/// </summary>
		public string FileName { get; set; } = default!;

		/// <summary>
		/// Тип данных файла
		/// </summary>
		public string? ContentType { get; set; }

		/// <summary>
		/// Бакет, в который сохраняется файл
		/// </summary>
		public string? Bucket { get; set; }

		/// <summary>
		/// Метаданные файла
		/// </summary>
		public IDictionary<string, string>? Metadata { get; set; }

		[Obsolete("Только для тестов")]
		public static FileContent CreateForTest(
			byte[] content,
			string fileName,
			string? contentType = "text/plain",
			string? bucket = null,
			IDictionary<string, string>? metadata = null)
			=> new()
			{
				FileName = fileName ?? throw new ArgumentNullException(nameof(fileName)),
				Content = new MemoryStream(content ?? throw new ArgumentNullException(nameof(content))),
				ContentType = contentType,
				Bucket = bucket,
				Metadata = metadata,
			};

		/// <inheritdoc/>
		public object Clone()
		{
			var clone = (FileContent)MemberwiseClone();
			clone.Content = new MemoryStream((int)Content.Length);
			Content.CopyTo(clone.Content);
			clone.Metadata = Metadata?.ToDictionary(x => x.Key, x => x.Value);
			return clone;
		}
	}
}
