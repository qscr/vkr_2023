using System;
using System.Collections.Generic;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Магазин
	/// </summary>
	public class Shop : EntityBase
	{
		/// <summary>
		/// Поле для <see cref="_owner"/>
		/// </summary>
		public const string OwnerFieldName = nameof(_owner);

		private User _owner;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Наименование магазина</param>
		/// <param name="owner">Владелец магазина</param>
		/// <param name="file">Картинки</param>
		public Shop(
			string name,
			User owner,
			File file)
		{
			Name = name;
			Owner = owner;
			File = file;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Shop()
		{
		}

		/// <summary>
		/// Наименование магазина
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Ид владельца магазина
		/// </summary>
		public Guid OwnerId { get; private set; }

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Владелец магазина
		/// </summary>
		public User? Owner
		{
			get => _owner;
			set
			{
				_owner = value ?? throw new RequiredFieldNotSpecifiedException("Владелец магазина");
				OwnerId = value.Id;
			}
		}

		/// <summary>
		/// Дизайны магазина
		/// </summary>
		public List<Layout>? Layouts { get; set; }

		/// <summary>
		/// Товары магазина
		/// </summary>
		public List<Product>? Products { get; set; }

		/// <summary>
		/// Картинка
		/// </summary>
		public File? File { get; set; }

		/// <summary>
		/// Рекламы
		/// </summary>
		public List<Advertising>? Advertisings { get; set; }

		#endregion

		#region Methods

		#endregion
	}
}
