using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.DeleteProducts
{
	/// <summary>
	/// Запрос на удаление списка товаров магазина
	/// </summary>
	public class DeleteProductsRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="request">Запрос</param>
		/// <exception cref="ArgumentNullException"></exception>
		public DeleteProductsRequest(DeleteProductsRequest request)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			ProductIds = request.ProductIds;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public DeleteProductsRequest()
		{
		}

		/// <summary>
		/// Ид товаров
		/// </summary>
		public List<Guid> ProductIds { get; set; }
	}
}
