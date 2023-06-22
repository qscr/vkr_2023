using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using MassTransit;

namespace DynamicStore.Api.Data.RabbitMq.Publishers
{
	/// <summary>
	/// Публикатор сообщений в очередь
	/// </summary>
	public class MessagePublisherBase : IRabbitMessagePublisher
	{
		private readonly IPublishEndpoint _publishEndpoint;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="publishEndpoint">MassTransit</param>
		public MessagePublisherBase(IPublishEndpoint publishEndpoint)
			=> _publishEndpoint = publishEndpoint;

		/// <inheritdoc/>
		public async Task PublishAsync<TMessage>(params TMessage[] messages)
			where TMessage : class
			=> await _publishEndpoint.PublishBatch(messages);
	}
}
