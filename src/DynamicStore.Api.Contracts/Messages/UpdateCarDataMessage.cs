using System;

namespace DynamicStore.Api.Contracts.Messages
{
	/// <summary>
	/// Сообщение в очередь
	/// </summary>
	public class UpdateCarDataMessage
	{
		/// <summary>
		/// ИД машины
		/// </summary>
		public Guid CarId { get; set; }

		/// <summary>
		/// Данные о машине
		/// </summary>
		public string Data { get; set; } = default!;
	}
}
