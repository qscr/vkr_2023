using System;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Файл
	/// </summary>
	public class File : EntityBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="address">Адрес в S3</param>
		/// <param name="name">Название файла</param>
		/// <param name="size">Размер файла в байтах</param>
		/// <param name="mimeType">Тип файла</param>
		public File(string address, string name, long size, string? mimeType = null)
		{
			if (string.IsNullOrWhiteSpace(address))
				throw new ValidationException("Не задан адрес файла в S3-хранилище");

			if (string.IsNullOrWhiteSpace(name))
				throw new ValidationException("Не задано название файла");

			if (size <= 0)
				throw new ValidationException($"Некорректный размер файла в байтах: {size}");

			Address = address;
			FileName = name;
			Size = size;
			ContentType = mimeType;
		}

		protected File()
		{
		}

		/// <summary>
		/// Идентификатор для S3-хранилища
		/// </summary>
		public string Address { get; protected set; } = default!;

		/// <summary>
		/// Название файла
		/// </summary>
		public string FileName { get; protected set; } = default!;

		/// <summary>
		/// Размер файла в байтах
		/// </summary>
		public long Size { get; protected set; }

		/// <summary>
		/// Mime-тип
		/// </summary>
		public string? ContentType { get; protected set; }

		/// <summary>
		/// Расширение файла
		/// </summary>
		/// <example>Extension("SomeFileName.pdf") возвратит ".pdf"</example>
		public string? Extension => System.IO.Path.GetExtension(FileName)?.Trim('.').ToLowerInvariant();

		/// <summary>
		/// Ид товара
		/// </summary>
		public Guid? ProductId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Категория
		/// </summary>
		public Category? Category { get; set; }

		/// <summary>
		/// Товар
		/// </summary>
		public Product? Product { get; set; }

		/// <summary>
		/// Магазин
		/// </summary>
		public Shop? Shop { get; set; }

		/// <summary>
		/// Пользователь
		/// </summary>
		public User? User { get; set; }

		/// <summary>
		/// Реклама
		/// </summary>
		public Advertising? Advertising { get; set; }

		#endregion

		#region Methods

		[Obsolete("Только для тестов")]
		public static File CreateForTest(
			string address = "s3address",
			string name = "test.txt",
			long size = 100,
			string? mimeType = "text/plain")
			=> new()
			{
				Address = address,
				FileName = name,
				Size = size,
				ContentType = mimeType,
			};

		#endregion
	}
}
