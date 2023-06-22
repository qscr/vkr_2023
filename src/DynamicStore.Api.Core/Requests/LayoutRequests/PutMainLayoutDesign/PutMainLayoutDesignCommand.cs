using DynamicStore.Api.Contracts.Requests.LayoutRequests.PutMainLayoutDesign;
using MediatR;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.PutMainLayoutDesign
{
	/// <summary>
	/// Запрос на изменение дизайна главной страницы
	/// </summary>
	public class PutMainLayoutDesignCommand : PutMainLayoutDesignRequest, IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="layoutDesign">Новый дизайн</param>
		public PutMainLayoutDesignCommand(string layoutDesign) => LayoutDesign = layoutDesign;
	}
}
