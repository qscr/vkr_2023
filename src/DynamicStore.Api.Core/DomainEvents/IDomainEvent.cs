using MediatR;

namespace DynamicStore.Api.Core.DomainEvents
{
	/// <summary>
	/// Доменное событие
	/// </summary>
	public interface IDomainEvent : INotification
	{
	}
}
