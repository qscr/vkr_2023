using System;
using System.Collections.Generic;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Товар
	/// </summary>
	public class Product : EntityBase
	{
		/// <summary>
		/// Поле для <see cref="_shop"/>
		/// </summary>
		public const string ShopFieldName = nameof(_shop);

		private Shop _shop;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Наименование товара</param>
		/// <param name="description">Описание товара</param>
		/// <param name="price">Цена товара</param>
		/// <param name="shop">Магазин</param>
		/// <param name="photos">Фотографии</param>
		public Product(
			string name,
			string? description,
			decimal price,
			Shop shop,
			List<File> photos)
		{
			Name = name;
			Description = description;
			Price = price;
			Shop = shop;
			Files = photos;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Product()
		{
		}

		/// <summary>
		/// Наименование товара
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание товара
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Цена товара
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Ид магазина
		/// </summary>
		public Guid ShopId { get; private set; }

		#region Navigation properties

		/// <summary>
		/// Владелец магазина
		/// </summary>
		public Shop? Shop
		{
			get => _shop;
			set
			{
				_shop = value ?? throw new RequiredFieldNotSpecifiedException("Владелец магазина");
				ShopId = value.Id;
			}
		}

		/// <summary>
		/// Категории
		/// </summary>
		public List<Category>? Categories { get; set; }

		/// <summary>
		/// Заказы
		/// </summary>
		public List<OrderProduct>? OrderProducts { get; set; }

		/// <summary>
		/// Картинки
		/// </summary>
		public List<File>? Files { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Обновление товара
		/// </summary>
		/// <param name="name">Наименование товара</param>
		/// <param name="description">Описание</param>
		/// <param name="price">Цена товара</param>
		/// <param name="categories">Категории товара</param>
		/// <param name="photos">Фотографии товара</param>
		public void Update(
			string name,
			string? description,
			decimal price,
			List<Category> categories,
			List<File> photos)
		{
			Name = name;
			Description = description;
			Price = price;
			Categories = categories;
			Files = photos;
		}

		#endregion
	}
}
