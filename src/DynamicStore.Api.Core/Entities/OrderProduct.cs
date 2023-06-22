using System;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Товар из заказа
	/// </summary>
	public class OrderProduct : EntityBase
	{
		/// <summary>
		/// Поле для <see cref="_order"/>
		/// </summary>
		public const string OrderFieldName = nameof(_order);

		/// <summary>
		/// Поле для <see cref="_product"/>
		/// </summary>
		public const string ProductFieldName = nameof(_product);

		private Order _order;
		private Product _product;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="order">Заказ</param>
		/// <param name="product">Товар</param>
		public OrderProduct(
			Order order,
			Product product)
		{
			ArgumentNullException.ThrowIfNull(order);
			ArgumentNullException.ThrowIfNull(product);

			Order = order;
			Product = product;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private OrderProduct()
		{
		}

		/// <summary>
		/// Ид заказа
		/// </summary>
		public Guid OrderId { get; private set; }

		/// <summary>
		/// Ид товара
		/// </summary>
		public Guid ProductId { get; private set; }

		#region Navigation properties

		/// <summary>
		/// Заказ
		/// </summary>
		public Order? Order
		{
			get => _order;
			private set
			{
				_order = value ?? throw new RequiredFieldNotSpecifiedException("Заказ");
				OrderId = value.Id;
			}
		}

		/// <summary>
		/// Товар
		/// </summary>
		public Product? Product
		{
			get => _product;
			set
			{
				_product = value ?? throw new RequiredFieldNotSpecifiedException("Товар");
				ProductId = value.Id;
			}
		}

		#endregion
	}
}
