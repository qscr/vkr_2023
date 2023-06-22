using System.Threading.Tasks;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Публикатор сообщений в очередь Rabbit
	/// </summary>
	public interface IRabbitMessagePublisher
	{
		/// <summary>
		/// Опубликовать сообщение в очередь
		/// </summary>
		/// <typeparam name="TMessage">Тип сообщения</typeparam>
		/// <param name="messages">Сообщения</param>
		/// <returns>-</returns>
		Task PublishAsync<TMessage>(params TMessage[] messages)
			where TMessage : class;
	}
}
