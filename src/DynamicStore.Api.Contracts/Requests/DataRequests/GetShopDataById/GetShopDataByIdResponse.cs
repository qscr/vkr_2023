using System;
using System.Collections.Generic;

namespace DynamicStore.Api.Contracts.Requests.DataRequests.GetShopData
{
	/// <summary>
	/// Ответ на запрос получения данных страницы магазина
	/// </summary>
	public class GetShopDataByIdResponse
	{
		/// <summary>
		/// Ответ на запрос
		/// </summary>
		public Dictionary<Guid, List<FileModel>> ResponseDictionary { get; set; }
	}

	public class FileModel
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public Guid FileId { get; set; }
	}
}
