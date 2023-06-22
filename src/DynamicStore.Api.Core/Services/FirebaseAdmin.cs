using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Models;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using Message = FirebaseAdmin.Messaging.Message;
using Notification = FirebaseAdmin.Messaging.Notification;

namespace DynamicStore.Api.Core.Services
{
	/// <summary>
	/// Сервис отправки уведомлений в мобилку
	/// </summary>
	public class FirebaseAdmin : IFirebaseAdmin
	{
		/// <summary>
		/// Инстанс файербейза
		/// </summary>
		private readonly FirebaseMessaging _messagingInstance;

		/// <summary>
		/// Инициализация Firebase'а
		/// </summary>
		public FirebaseAdmin(FirebaseServiceAccountOptions options)
		{
			var app = FirebaseApp.Create(new AppOptions()
			{
				Credential = GoogleCredential.FromStream(new MemoryStream(
					Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(options)))),
			});
			_messagingInstance = FirebaseMessaging.GetMessaging(app);
		}

		/// <summary>
		/// Отправить пачку пушей
		/// </summary>
		/// <param name="notifiableUsersList">Токены пользователей</param>
		/// <param name="title">Заголовок пуша</param>
		/// <param name="imageUrl">Ссылка на картинку</param>
		/// <param name="data">Доп данные</param>
		/// <returns>Список со статусами отправки</returns>
		public async Task<List<BatchResponse>> SendNotificationsAsync(
			List<FirebaseUser> notifiableUsersList,
			string title,
			string? imageUrl = null,
			Dictionary<string, string>? data = null)
		{
			if (notifiableUsersList is null)
				throw new ArgumentNullException(nameof(notifiableUsersList));
			if (title is null)
				throw new ArgumentNullException(nameof(title));

			// Файербейз может отправлять только 500 за раз, поэтому делим на части
			var chunks = notifiableUsersList
				.SelectMany(x => (x.MobileApplicationTokens ?? new List<string>()).Select(t => (User: x, Token: t)))
				.Select((s, i) => new { Value = s, Index = i })
				.GroupBy(x => x.Index / 500)
				.Select(grp => grp.Select(x => x.Value).ToList())
				.ToList();

			var responses = new List<BatchResponse>();

			foreach (var chunk in chunks)
			{
				var messages = chunk
					.Select(userToken =>
					{
						var message = new Message
						{
							Token = userToken.Token,
							Notification = new Notification
							{
								Body = userToken.User.Message,
								Title = title,
							},
							Data = new ReadOnlyDictionary<string, string>(data ?? new Dictionary<string, string>()),
							Android = new AndroidConfig
							{
								Notification = new AndroidNotification
								{
									Sound = "default",
								},
							},
							Apns = new ApnsConfig
							{
								Aps = new Aps
								{
									Sound = "default",
								},
							},
						};

						if (!string.IsNullOrEmpty(imageUrl))
						{
							message.Notification.ImageUrl = imageUrl;
						}

						return message;
					})
					.ToList();

				responses.Add(await _messagingInstance.SendAllAsync(messages));
			}

			return responses;
		}
	}
}
