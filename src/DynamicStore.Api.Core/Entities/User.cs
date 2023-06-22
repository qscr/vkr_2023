using System;
using System.Collections.Generic;
using DynamicStore.Api.Core.Exceptions;
using DynamicStore.Api.Core.Validators;
using ValidationException = DynamicStore.Api.Core.Exceptions.ValidationException;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Пользователь
	/// </summary>
	public class User : EntityBase
	{
		/// <summary>
		/// Поле для <see cref="_shop"/>
		/// </summary>
		public const string ShopFieldName = nameof(_shop);

		private Shop? _shop;
		private string _name = default!;
		private string _email = default!;
		private string _passwordHash = default!;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Имя пользователя</param>
		/// <param name="email">Email</param>
		/// <param name="hasUserWithEmail">Делегат проверки уникальности почтового адреса</param>
		/// <param name="passwordHash">Хэш пароля</param>
		/// <param name="file">Картинки</param>
		public User(
			string name,
			string email,
			HasUserWithEmail hasUserWithEmail,
			string passwordHash,
			File file)
		{
			Name = name;
			SetEmail(email, hasUserWithEmail);
			PasswordHash = passwordHash;
			File = file;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		private User()
		{
		}

		/// <summary>
		/// Делегат проверки уникальности почтового адреса
		/// </summary>
		/// <param name="email">Почтовый адрес</param>
		/// <param name="user">Пользователь</param>
		/// <returns>Является ли уникальным почтовым адресом</returns>
		public delegate bool HasUserWithEmail(string email, User user);

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new RequiredFieldNotSpecifiedException("Имя пользователя");

				_name = value;
			}
		}

		/// <summary>
		/// Email
		/// </summary>
		public string Email
		{
			get => _email;
			protected set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new RequiredFieldNotSpecifiedException("Email");

				if (!EmailValidator.IsValidEmailAddress(value, requiredDotInDomainName: true))
					throw new InvalidFieldFormatException(nameof(Email));

				_email = value;
			}
		}

		/// <summary>
		/// Хэш пароля
		/// </summary>
		public string PasswordHash
		{
			get => _passwordHash;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new RequiredFieldNotSpecifiedException("Пароль");

				_passwordHash = value;
			}
		}

		/// <summary>
		/// Ид магазина
		/// </summary>
		public Guid? ShopId { get; private set; }

		/// <summary>
		/// Ид картинки
		/// </summary>
		public Guid? FileId { get; set; }

		#region Navigation properties

		/// <summary>
		/// Магазин пользователя
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

		/// <summary>
		/// Заказы
		/// </summary>
		public List<Order>? Orders { get; set; }

		/// <summary>
		/// Картинка
		/// </summary>
		public File? File { get; set; }

		#endregion

		#region Methods

		public void SetEmail(string email, HasUserWithEmail hasUserWithEmail)
		{
			if (hasUserWithEmail is null)
				throw new ArgumentNullException(nameof(hasUserWithEmail));

			var isDuplicate = hasUserWithEmail(email, this);
			if (isDuplicate)
				throw new ValidationException("Пользователь с таким email уже существует");

			Email = email;
		}

		/// <summary>
		/// Метод для тестов
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="email">Email</param>
		/// <param name="passwordHash">Хэш пароля</param>
		/// <returns>-</returns>
		[Obsolete("Только для тестов")]
		public static User CreateForTest(
			string name = default!,
			string email = default!,
			string passwordHash = default!)
			=> new()
			{
				_name = name,
				_email = email,
				_passwordHash = passwordHash,
			};

		#endregion
	}
}
