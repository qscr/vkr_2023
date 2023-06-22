using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Transform;
using DynamicStore.Api.Contracts.Requests.DataRequests.GetShopData;
using DynamicStore.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DynamicStore.Api.Core.Requests.DataRequests.GetShopDataById
{
	/// <summary>
	/// Обработчик запроса <see cref="GetShopDataByIdQuery"/>
	/// </summary>
	public class GetShopDataByIdQueryHandler : IRequestHandler<GetShopDataByIdQuery, GetShopDataByIdResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetShopDataByIdQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetShopDataByIdResponse> Handle(
			GetShopDataByIdQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var dict = new Dictionary<Guid, List<FileModel>>();
			var advertisements = _dbContext.Advertisements
				.Where(x => x.ShopId == request.Id)
				.Where(x => x.Key != null)
				.ToList()
				.GroupBy(x => x.Key)
				.ToDictionary(x => x.Key, x => x.Select(y => y.FileId));

			foreach (var key in advertisements)
			{
				var list = new List<FileModel>();
				foreach (var value in key.Value)
				{
					list.Add(new()
					{
						FileId = value,
					});
				}
				dict.Add(new KeyValuePair<Guid, List<FileModel>>((Guid)key.Key!, list));
			}

			var json = JsonConvert.SerializeObject(dict);

			return new GetShopDataByIdResponse
			{
				ResponseDictionary = dict,
			};
		}
	}
}
