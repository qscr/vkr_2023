namespace DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts
{
	/// <summary>
	/// Запрос на получение списка товаров магазина
	/// </summary>
	public class GetShopProductsRequest
	{
		/// <summary>
		/// Номер страницы, начиная с 1
		/// </summary>
		public int PageNumber { get; set; }

		/// <summary>
		/// Размер страницы
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// Поле сортировки
		/// </summary>
		public string? OrderBy { get; set; }

		/// <summary>
		/// Сортировка по возрастанию
		/// </summary>
		public bool IsAscending { get; set; }
	}
}
