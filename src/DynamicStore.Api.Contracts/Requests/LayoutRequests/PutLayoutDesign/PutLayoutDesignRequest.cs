namespace DynamicStore.Api.Contracts.Requests.LayoutRequests.PutLayoutDesign
{
	/// <summary>
	/// Запрос на изменения верстки по ид
	/// </summary>
	public class PutLayoutDesignRequest
	{
		/// <summary>
		/// Строка с дизайном магазина
		/// </summary>
		public string Data { get; set; } = default!;
	}
}
