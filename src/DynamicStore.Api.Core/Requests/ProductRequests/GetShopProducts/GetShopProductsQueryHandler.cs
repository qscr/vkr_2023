using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.ProductRequests.GetShopProducts;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.ProductRequests.GetShopProducts
{
	/// <summary>
	/// Обработчик запроса <see cref="GetShopProductsQuery"/>
	/// </summary>
	public class GetShopProductsQueryHandler : IRequestHandler<GetShopProductsQuery, GetShopProductsResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserContext _userContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userContext">Контекст пользователя</param>
		public GetShopProductsQueryHandler(
			IDbContext dbContext,
			IUserContext userContext)
		{
			_dbContext = dbContext;
			_userContext = userContext;
		}

		/// <inheritdoc/>
		public async Task<GetShopProductsResponse> Handle(
			GetShopProductsQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Products
				.Include(x => x.Categories)
				.Include(x => x.Files)
				.Where(x => x.ShopId == _userContext.ShopId);

			var products = await query
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			var list = products
				.Select(x => new GetShopProductsResponseItem
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Price = x.Price,
					CategoryIds = x.Categories?.Select(c => c.Id).ToList(),
					PhotoIds = x.Files?.Select(f => f.Id).ToList(),
				})
				.ToList();

			var count = await query.CountAsync(cancellationToken);

			return new GetShopProductsResponse(list, count);
		}
	}
}
