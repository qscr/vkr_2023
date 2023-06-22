using System;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Верстка
	/// </summary>
	public class Layout : EntityBase, ISoftDeletable
	{
		/// <summary>
		/// Поле для <see cref="_shop"/>
		/// </summary>
		public const string ShopFieldName = nameof(_shop);

		private Shop? _shop;
		private string _layoutDesign;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="activeFrom">Магазин</param>
		/// <param name="layoutDesign">Магазин</param>
		/// <param name="shop">Магазин</param>
		public Layout(
			DateTime activeFrom,
			string layoutDesign,
			Shop shop)
		{
			ActiveFrom = activeFrom;
			LayoutDesign = layoutDesign;
			Shop = shop;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Layout()
		{
		}

		/// <summary>
		/// Дата активации дизайна
		/// </summary>
		public DateTime ActiveFrom { get; set; }

		/// <summary>
		/// Дизайн страницы в формате JSON
		/// </summary>
		public string LayoutDesign
		{
			get => _layoutDesign;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new RequiredFieldNotSpecifiedException("Дизайн страницы в формате JSON");

				_layoutDesign = value;
			}
		}

		/// <summary>
		/// Ид магазина
		/// </summary>
		public Guid? ShopId { get; private set; }

		/// <summary>
		/// Признак удаленности
		/// </summary>
		public bool IsDeleted { get; set; }

		#region Navigation properties

		/// <summary>
		/// Магазин
		/// </summary>
		public Shop? Shop
		{
			get => _shop;
			set
			{
				_shop = value;
				ShopId = value?.IsNew == true ? null : value?.Id;
			}
		}

		#endregion
	}
}
