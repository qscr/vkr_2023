using System;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopLayoutById;
using MediatR;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetShopLayoutBuId
{
	/// <summary>
	/// Команда запроса получения дизайна магазина по ид
	/// </summary>
	public class GetShopLayoutByIdQuery : IRequest<GetShopLayoutByIdResponse>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Ид сущности</param>
		public GetShopLayoutByIdQuery(Guid id) => Id = id;

		/// <summary>
		/// Ид сущности
		/// </summary>
		public Guid Id { get; set; }
	}
}
