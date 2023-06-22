using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Models;
using FirebaseAdmin.Messaging;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Сервис отправки уведомлений в мобилку
	/// </summary>
	public interface IFirebaseAdmin
	{
		/// <summary>
		/// Отправить пачку пушей
		/// </summary>
		/// <param name="notifiableUsersList">Токены пользователей</param>
		/// <param name="title">Заголовок пуша</param>
		/// <param name="imageUrl">Ссылка на картинку</param>
		/// <param name="data">Доп данные</param>
		/// <returns>Список со статусами отправки</returns>
		Task<List<BatchResponse>> SendNotificationsAsync(
			List<FirebaseUser> notifiableUsersList,
			string title,
			string? imageUrl = null,
			Dictionary<string, string>? data = null);
	}
}
