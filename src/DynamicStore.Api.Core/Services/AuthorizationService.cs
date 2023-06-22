using System;
using System.Linq;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;

namespace DynamicStore.Api.Core.Services
{
	/// <inheritdoc />
	public class AuthorizationService : IAuthorizationService
	{
		private readonly IUserContext _userContext;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="userContext">Контекст пользователя</param>
		public AuthorizationService(IUserContext userContext) => _userContext = userContext;

		/// <inheritdoc />
		public IQueryable<Layout> FilterUpdateLayout(IQueryable<Layout> query)
		{
			if (query is null)
				throw new ArgumentNullException(nameof(query));

			return query.Where(x => x.Shop!.OwnerId == _userContext.CurrentUserId);
		}

		/// <inheritdoc />
		public IQueryable<Layout> FilterUpdateMainLayout(IQueryable<Layout> query)
		{
			if (query is null)
				throw new ArgumentNullException(nameof(query));

			return query.Where(x => _userContext.UserName == "Administrator");
		}

		/// <inheritdoc />
		public IQueryable<Product> FilterUpdateProducts(IQueryable<Product> query)
		{
			if (query is null)
				throw new ArgumentNullException(nameof(query));

			return query.Where(x => x.Shop!.OwnerId == _userContext.CurrentUserId);
		}
	}
}
