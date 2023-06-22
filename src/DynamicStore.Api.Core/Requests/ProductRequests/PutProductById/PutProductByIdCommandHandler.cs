using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.ProductRequests.PutProductById
{
	/// <summary>
	/// Обработчик запроса <see cref="PutProductByIdCommand"/>
	/// </summary>
	public class PutProductByIdCommandHandler : IRequestHandler<PutProductByIdCommand>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserContext _userContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userContext">Контекст пользователя</param>
		public PutProductByIdCommandHandler(
			IDbContext dbContext,
			IUserContext userContext)
		{
			_dbContext = dbContext;
			_userContext = userContext;
		}

		/// <inheritdoc/>
		public async Task<Unit> Handle(
			PutProductByIdCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var product = await _dbContext.Products
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
				?? throw new EntityNotFoundException<Product>(request.Id);

			var categories = await _dbContext.Categories
				.Where(x => request.CategoryIds!.Contains(x.Id))
				.ToListAsync(cancellationToken);

			var photos = await _dbContext.Files
				.Where(x => request.PhotoIds!.Contains(x.Id))
				.ToListAsync(cancellationToken);

			product.Update(
				name: request.Name,
				description: request.Description,
				price: request.Price,
				categories: categories,
				photos: photos);

			await _dbContext.SaveChangesAsync(cancellationToken);

			return default;
		}
	}
}
