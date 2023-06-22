namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.PutMainLayoutDesign
{
	/// <summary>
	/// Запрос на изменения верстки главной страницы
	/// </summary>
	public class PutMainLayoutDesignRequest
	{
		/// <summary>
		/// Строка с дизайном магазина
		/// </summary>
		public string LayoutDesign { get; set; } = default!;
	}
}
