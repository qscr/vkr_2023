using System;
using DynamicStore.Api.Core.Abstractions;

namespace DynamicStore.Api.Core.Services
{
	/// <inheritdoc/>
	public class DateTimeProvider : IDateTimeProvider
	{
		/// <inheritdoc/>
		public DateTime UtcNow => DateTime.UtcNow;
	}
}
