using System;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.LayoutRequests.GetMainLayout;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.LayoutRequests.GetMainLayout
{
	/// <summary>
	/// Обработчик запроса <see cref="GetMainLayoutQuery"/>
	/// </summary>
	public class GetMainLayoutQueryHandler : IRequestHandler<GetMainLayoutQuery, GetMainLayoutResponse>
	{
		private readonly IDbContext _dbContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		public GetMainLayoutQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

		/// <inheritdoc/>
		public async Task<GetMainLayoutResponse> Handle(
			GetMainLayoutQuery request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var layout = await _dbContext.Layouts
				.FirstOrDefaultAsync(x => x.Shop == null, cancellationToken)
				?? throw new NotFoundException("Не найден дизайн к главной странице");

			return new GetMainLayoutResponse
			{
				Id = layout.Id,
				ActiveFrom = layout.ActiveFrom,
				LayoutDesign = layout.LayoutDesign,
				FileId = layout.Shop?.FileId,
			};
		}
	}
}
