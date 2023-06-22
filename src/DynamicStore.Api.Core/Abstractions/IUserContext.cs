using System;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Контекст текущего пользователя
	/// </summary>
	public interface IUserContext
	{
		/// <summary>
		/// ИД текущего пользователя
		/// </summary>
		Guid CurrentUserId { get; }

		/// <summary>
		/// Имя текущего пользователя
		/// </summary>
		string UserName { get; }

		/// <summary>
		/// Ид магазина текущего пользователя
		/// </summary>
		Guid? ShopId { get; }
	}
}
