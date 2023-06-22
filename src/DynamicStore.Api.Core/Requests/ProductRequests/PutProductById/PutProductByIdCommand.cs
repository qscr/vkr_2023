using System;
using DynamicStore.Api.Contracts.Requests.ProductRequests.PutProductById;
using MediatR;

namespace DynamicStore.Api.Core.Requests.ProductRequests.PutProductById
{
	/// <summary>
	/// Команда запроса <see cref="PutProductByIdRequest"/>
	/// </summary>
	public class PutProductByIdCommand : PutProductByIdRequest, IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Ид сущности</param>
		/// <param name="request">Запрос</param>
		public PutProductByIdCommand(Guid id, PutProductByIdRequest request)
		: base(request) => Id = id;

		/// <summary>
		/// Ид сущности
		/// </summary>
		public Guid Id { get; set; }
	}
}
