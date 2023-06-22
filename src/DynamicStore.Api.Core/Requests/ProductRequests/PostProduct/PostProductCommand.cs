using System;
using System.Collections.Generic;
using DynamicStore.Api.Contracts.Requests.ProductRequests.PostProduct;
using MediatR;

namespace DynamicStore.Api.Core.Requests.ProductRequests.PostProduct
{
	/// <summary>
	/// Запрос на создание нового товара
	/// </summary>
	public class PostProductCommand : PostProductRequest, IRequest<PostProductResponse>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="name">Наименование товара</param>
		/// <param name="description">Описание товара</param>
		/// <param name="price">Цена товара</param>
		/// <param name="photoIds">Ид фотографий товара</param>
		public PostProductCommand(
			string name,
			string? description,
			decimal price,
			List<Guid>? photoIds)
		{
			Name = name;
			Description = description;
			Price = price;
			PhotoIds = photoIds;
		}
	}
}
