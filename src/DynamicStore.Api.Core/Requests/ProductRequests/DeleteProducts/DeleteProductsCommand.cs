using DynamicStore.Api.Contracts.Requests.ProductRequests.DeleteProducts;
using MediatR;

namespace DynamicStore.Api.Core.Requests.ProductRequests.DeleteProducts
{
	/// <summary>
	/// Команда удаления списка товаров
	/// </summary>
	public class DeleteProductsCommand : DeleteProductsRequest, IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="request">Запрос</param>
		public DeleteProductsCommand(DeleteProductsRequest request)
			: base(request)
		{
		}
	}
}
