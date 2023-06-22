using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.ProductRequests.DeleteProducts
{
	/// <summary>
	/// Обработчик запроса <see cref="DeleteProductsCommand"/>
	/// </summary>
	public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand>
	{
		private readonly IDbContext _dbContext;
		private readonly IAuthorizationService _authorizationService;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="authorizationService">Сервис авторизации</param>
		public DeleteProductsCommandHandler(
			IDbContext dbContext,
			IAuthorizationService authorizationService)
		{
			_dbContext = dbContext;
			_authorizationService = authorizationService;
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			DeleteProductsCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var ids = request.ProductIds;
			if (!ids.Any())
				return default;

			var query = _authorizationService.FilterUpdateProducts(_dbContext.Products);
			var products = await query
				.Where(x => ids.Contains(x.Id))
				.ToListAsync(cancellationToken);

			var notFoundEntities = ids
				.Where(id => products.All(x => id != x.Id))
				.ToList();

			if (notFoundEntities.Any())
				throw new EntityNotFoundException<Product>(notFoundEntities);

			_dbContext.Products.RemoveRange(products);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return default;
		}
	}
}
