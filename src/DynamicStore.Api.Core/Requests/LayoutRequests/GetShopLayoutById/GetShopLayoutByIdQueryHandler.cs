using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetShopLayoutById;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetShopLayoutBuId
{
	/// <summary>
	/// Обработчик запроса <see cref="GetShopLayoutByIdQuery"/>
	/// </summary>
	public class GetShopLayoutByIdQueryHandler : IRequestHandler<GetShopLayoutByIdQuery, GetShopLayoutByIdResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetShopLayoutByIdQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetShopLayoutByIdResponse> Handle(
			GetShopLayoutByIdQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var layout = await _dbContext.Layouts
				.Where(x => !x.IsDeleted)
				.FirstOrDefaultAsync(x => x.ShopId == request.Id, cancellationToken)
				?? throw new NotFoundException("Не найден дизайн к странице магазина");

			return new GetShopLayoutByIdResponse
			{
				Id = layout.Id,
				ActiveFrom = layout.ActiveFrom,
				LayoutDesign = layout.LayoutDesign,
				ShopId = layout.ShopId,
			};
		}
	}
}
