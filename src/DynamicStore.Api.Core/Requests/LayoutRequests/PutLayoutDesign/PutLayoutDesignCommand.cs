using DynamicStore.Api.Contracts.Requests.LayoutRequests.PutLayoutDesign;
using MediatR;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.PutLayoutDesign
{
	/// <summary>
	/// Запрос на изменение дизайна магазина по ид
	/// </summary>
	public class PutLayoutDesignCommand : PutLayoutDesignRequest, IRequest
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="data">Новый дизайн</param>
		public PutLayoutDesignCommand(
			string data) => Data = data;
	}
}
