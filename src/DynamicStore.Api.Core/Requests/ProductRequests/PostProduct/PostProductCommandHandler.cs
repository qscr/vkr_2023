using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicStore.Api.Contracts.Requests.ProductRequests.PostProduct;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Api.Core.Requests.ProductRequests.PostProduct
{
	/// <summary>
	/// Обработчик команды <see cref="PostProductCommand"/>
	/// </summary>
	public class PostProductCommandHandler : IRequestHandler<PostProductCommand, PostProductResponse>
	{
		private readonly IDbContext _dbContext;
		private readonly IUserContext _userContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="dbContext">Контекст БД</param>
		/// <param name="userContext">Контекст пользователя</param>
		public PostProductCommandHandler(
			IDbContext dbContext,
			IUserContext userContext)
		{
			_dbContext = dbContext;
			_userContext = userContext;
		}

		/// <inheritdoc/>
		public async Task<PostProductResponse> Handle(
			PostProductCommand request,
			CancellationToken cancellationToken)
		{
			if (request is null)
				throw new ArgumentNullException(nameof(request));

			var shop = await _dbContext.Shops
				.FirstOrDefaultAsync(x => x.Id == _userContext.ShopId, cancellationToken)
				?? throw new NotFoundException($"Не найден магазин с ид - {_userContext.ShopId}");

			var photos = await _dbContext.Files
				.Where(x => request.PhotoIds!.Contains(x.Id))
				.ToListAsync(cancellationToken);

			var product = new Product(
				name: request.Name,
				description: request.Description,
				price: request.Price,
				shop: shop,
				photos: photos);

			await _dbContext.Products.AddAsync(product, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return new PostProductResponse(product.Id);
		}
	}
}
