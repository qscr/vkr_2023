using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.ProductRequests.PutProductById
{
	/// <summary>
	/// Запрос на обновление данных товара
	/// </summary>
	public class PutProductByIdRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="request">Запрос</param>
		/// <exception cref="ArgumentNullException"></exception>
		public PutProductByIdRequest(PutProductByIdRequest request)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			Name = request.Name;
			Description = request.Description;
			Price = request.Price;
			PhotoIds = request.PhotoIds;
			CategoryIds = request.CategoryIds;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public PutProductByIdRequest()
		{
		}

		/// <summary>
		/// Наименование товара
		/// </summary>
		public string Name { get; set; } = default!;

		/// <summary>
		/// Описание товара
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Цена товара
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Ид фотографий товара
		/// </summary>
		public List<Guid>? PhotoIds { get; set; }

		/// <summary>
		/// Ид категорий товара
		/// </summary>
		public List<Guid>? CategoryIds { get; set; }
	}
}
