using System;
using DynamicStore.Api.Contracts.Requests.DataRequests.GetShopData;
using MediatR;

namespace DynamicStore.Api.Core.Requests.DataRequests.GetShopDataById
{
	/// <summary>
	/// Запрос данных с странице магазина по ид
	/// </summary>
	public class GetShopDataByIdQuery : GetShopDataByIdResponse, IRequest<GetShopDataByIdResponse>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Ид сущности</param>
		public GetShopDataByIdQuery(Guid id) => Id = id;

		/// <summary>
		/// Ид сущности
		/// </summary>
		public Guid Id { get; set; }
	}
}
