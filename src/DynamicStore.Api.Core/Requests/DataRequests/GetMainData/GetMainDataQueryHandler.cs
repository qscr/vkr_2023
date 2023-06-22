using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.DataRequests.GetMainData;
using DynamicStore.Api.Core.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.DataRequests.GetMainData
{
	/// <summary>
	/// Обработчик запроса <see cref="GetMainDataQuery"/>
	/// </summary>
	public class GetMainDataQueryHandler : IRequestHandler<GetMainDataQuery, GetMainDataResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetMainDataQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetMainDataResponse> Handle(
			GetMainDataQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var shops = await _dbContext.Shops
				.Select(s => new GetMainDataResponseShop
				{
					Id = s.Id,
					Name = s.Name,
					OwnerId = s.OwnerId,
					FileId = s.FileId,
				})
				.ToListAsync(cancellationToken);

			var products = await _dbContext.Products
				.Include(p => p.Categories)
				.OrderBy(p => p.ModifiedOn)
				.Take(2)
				.Select(p => new GetMainDataResponseProduct
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					ShopId = p.ShopId,
					FileIds = p.Files!
						.Select(x => x.Id)
						.ToList(),
					Description = p.Description,
				})
				.ToListAsync(cancellationToken);

			var advertisements = await _dbContext.Advertisements
				.Select(a => new GetMainDataResponseAdvertising
				{
					Id = a.Id,
					Name = a.Name,
					Route = a.Route,
					FileId = a.FileId,
				})
				.ToListAsync(cancellationToken);

			var categories = await _dbContext.Categories
				.Select(x => new GetMainDataResponseCategory
				{
					Id = x.Id,
					Code = x.Code,
					Name = x.Name,
					Description = x.Description,
					FileId = x.FileId,
				})
				.ToListAsync(cancellationToken);

			return new GetMainDataResponse
			{
				Shops = shops,
				Products = products,
				Advertisements = advertisements,
				Categories = categories,
			};
		}
	}
}
