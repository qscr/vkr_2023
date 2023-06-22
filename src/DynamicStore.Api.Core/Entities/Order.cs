using System;
using System.Collections.Generic;
using DynamicStore.Api.Core.Exceptions;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Заказ
	/// </summary>
	public class Order : EntityBase
	{
		/// <summary>
		/// Поле для <see cref="_user"/>
		/// </summary>
		public const string UserFieldName = nameof(_user);

		private User _user;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="quantity">Количество товаров</param>
		/// <param name="totalPrice">Общая стоимость</param>
		/// <param name="isPayed">Оплачен ли заказ</param>
		/// <param name="user">Пользователь</param>
		public Order(
			int quantity,
			decimal totalPrice,
			bool isPayed,
			User user)
		{
			Quantity = quantity;
			TotalPrice = totalPrice;
			IsPayed = isPayed;
			User = user;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private Order()
		{
		}

		/// <summary>
		/// Количество товаров
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Общая стоимость
		/// </summary>
		public decimal TotalPrice { get; set; }

		/// <summary>
		/// Оплачен ли заказ
		/// </summary>
		public bool IsPayed { get; set; }

		/// <summary>
		/// Ид пользователя
		/// </summary>
		public Guid UserId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Пользователь
		/// </summary>
		public User? User
		{
			get => _user;
			set
			{
				_user = value ?? throw new RequiredFieldNotSpecifiedException("Пользователь");
				UserId = value.Id;
			}
		}

		/// <summary>
		/// Товары
		/// </summary>
		public List<OrderProduct>? OrderProducts { get; set; }

		#endregion
	}
}
