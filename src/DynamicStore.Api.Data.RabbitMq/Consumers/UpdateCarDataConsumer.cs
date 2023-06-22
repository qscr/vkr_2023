using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Messages;
using Microsoft.Extensions.Logging;

namespace DynamicStore.Api.Data.RabbitMq.Consumers
{
	/// <summary>
	/// Тестовый потребитель очереди
	/// </summary>
	public class UpdateCarDataConsumer : ConsumerBase<UpdateCarDataMessage>
	{
		private readonly ILogger<UpdateCarDataConsumer> _logger;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="logger">Логгер</param>
		public UpdateCarDataConsumer(ILogger<UpdateCarDataConsumer> logger)
			=> _logger = logger;

		/// <inheritdoc/>
		public override async Task ConsumeAsync(MessageContextBase message)
		{
			await Task.CompletedTask;
			_logger.LogInformation("Message received {Message}", message.Message.Data);
		}
	}
}
