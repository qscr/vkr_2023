using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Категория
	/// </summary>
	public class Category : EntityBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="code">Код категории</param>
		/// <param name="name">Наименование категории</param>
		/// <param name="key">Ключ</param>
		/// <param name="description">Описание категории</param>
		/// <param name="file">Картинка</param>
		public Category(
			string code,
			string name,
			Guid? key,
			string? description,
			File file)
		{
			Code = code;
			Name = name;
			Key = key;
			Description = description;
			File = file;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Category()
		{
		}

		/// <summary>
		/// Код категории
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Наименование категории
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание категории
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Ключ
		/// </summary>
		public Guid? Key { get; set; }

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Товары
		/// </summary>
		public List<Product>? Products { get; set; }

		/// <summary>
		/// Картинка
		/// </summary>
		public File? File { get; set; }

		#endregion
	}
}
