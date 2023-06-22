using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DynamicStore.Api.Core.DomainEvents;

namespace DynamicStore.Api.Core.Entities
{
	/// <summary>
	/// Базовая сущность
	/// </summary>
	public abstract class EntityBase
	{
		/// <summary>
		/// Доменные события
		/// </summary>
		private ConcurrentQueue<IDomainEvent>? _domainEvents;

		/// <summary>
		/// ИД сущности
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Дата создания сущности
		/// </summary>
		public DateTime CreatedOn { get; set; }

		/// <summary>
		/// Дата последнего изменения сущности
		/// </summary>
		public DateTime ModifiedOn { get; set; }

		/// <summary>
		/// Является ли сущность новой
		/// </summary>
		public bool IsNew => Id == default;

		/// <summary>
		/// Добавить доменное событие
		/// </summary>
		/// <param name="eventItem">Событие</param>
		public void AddDomainEvent(IDomainEvent eventItem)
		{
			if (eventItem is null)
				throw new ArgumentNullException(nameof(eventItem));

			_domainEvents ??= new ConcurrentQueue<IDomainEvent>();
			_domainEvents.Enqueue(eventItem);
		}

		/// <summary>
		/// Получить доменные события и очистить их список
		/// </summary>
		/// <returns>Доменные события</returns>
		public IEnumerable<IDomainEvent> RetrieveDomainEvents()
		{
			if (_domainEvents is null)
				return Enumerable.Empty<IDomainEvent>();

			var events = _domainEvents.ToList();
			_domainEvents.Clear();
			return events;
		}

		/// <summary>
		/// Есть ли доменное событие
		/// </summary>
		/// <typeparam name="TEventType">Тип доменного события</typeparam>
		/// <param name="predicate">Предикат с фильтром события</param>
		/// <returns>Истинность</returns>
		public bool HasDomainEvent<TEventType>(Func<TEventType, bool>? predicate = null)
			=> _domainEvents?.Any(x => x is TEventType @event && predicate?.Invoke(@event) != false) ?? false;

		/// <summary>
		/// Добавить доменное событие, если оно отсутствует
		/// </summary>
		/// <typeparam name="TEventType">Тип доменного события</typeparam>
		/// <param name="domainEvent">Доменное событие</param>
		public void CheckAndAddDomainEvent<TEventType>(TEventType domainEvent)
			where TEventType : IDomainEvent
		{
			if (!HasDomainEvent<TEventType>())
				AddDomainEvent(domainEvent);
		}
	}
}
