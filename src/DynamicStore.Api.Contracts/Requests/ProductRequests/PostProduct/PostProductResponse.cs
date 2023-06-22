using System;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.PostProduct
{
	/// <summary>
	/// Ответ на запрос <see cref="PostProductRequest"/>
	/// </summary>
	public class PostProductResponse
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Ид созданной записи</param>
		public PostProductResponse(Guid id) => Id = id;

		/// <summary>
		/// Ид созданной записи
		/// </summary>
		public Guid Id { get; set; }
	}
}
