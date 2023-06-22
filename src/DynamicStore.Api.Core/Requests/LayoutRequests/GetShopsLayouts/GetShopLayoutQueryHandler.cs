using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopsLayouts;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetShopsLayouts
{
	/// <summary>
	/// Обработчик запроса <see cref="GetShopLayoutQuery"/>
	/// </summary>
	public class GetShopLayoutQueryHandler : IRequestHandler<GetShopLayoutQuery, GetShopsLayoutsResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetShopLayoutQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetShopsLayoutsResponse> Handle(
			GetShopLayoutQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var query = _dbContext.Layouts;

			var layouts = await query
				.OrderBy(request)
				.SkipTake(request)
				.ToListAsync(cancellationToken);

			var list = layouts
				.Select(x => new GetShopsLayoutsResponseItem
				{
					Id = x.Id,
					ActiveFrom = x.ActiveFrom,
					LayoutDesign = x.LayoutDesign,
					ShopId = x.Shop?.Id,
					FileId = x.Shop?.FileId,
				})
				.ToList();

			var count = await query.CountAsync(cancellationToken);

			return new GetShopsLayoutsResponse(list, count);
		}
	}
}
