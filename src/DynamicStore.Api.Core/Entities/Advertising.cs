using System;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Реклама
	/// </summary>
	public class Advertising : EntityBase
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Наименование рекламы</param>
		/// <param name="route">Путь</param>
		/// <param name="key">Ключ</param>
		/// <param name="file">Картинки</param>
		/// <param name="shop">Магазин</param>
		public Advertising(
			string name,
			string route,
			Guid? key,
			File file,
			Shop shop)
		{
			Name = name;
			Route = route;
			Key = key;
			File = file;
			Shop = shop;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Advertising()
		{
		}

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Путь
		/// </summary>
		public string Route { get; set; } = default!;

		/// <summary>
		/// Ключ
		/// </summary>
		public Guid? Key { get; set; }

		/// <summary>
		/// Картинка
		/// </summary>
		public Guid FileId { get; set; }

		/// <summary>
		/// Ид магазина
		/// </summary>
		public Guid? ShopId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Картинка
		/// </summary>
		public File File { get; set; }

		/// <summary>
		/// Магазин
		/// </summary>
		public Shop? Shop { get; set; }

		#endregion
	}
}
