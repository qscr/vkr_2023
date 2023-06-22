using System;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Провайдер даты
	/// </summary>
	public interface IDateTimeProvider
	{
		/// <summary>
		/// Сейчас
		/// </summary>
		DateTime UtcNow { get; }
	}
}
