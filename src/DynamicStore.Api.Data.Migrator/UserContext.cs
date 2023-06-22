using System;
using DynamicStore.Api.Core.Abstractions;

namespace DynamicStore.Api.Data.Migrator
{
	/// <summary>
	/// Мок юзер контекста для контекста БД
	/// </summary>
	internal class UserContext : IUserContext
	{
		/// <inheritdoc/>
		public Guid CurrentUserId => throw new NotImplementedException();

		/// <inheritdoc/>
		public string UserName => throw new NotImplementedException();

		/// <inheritdoc/>
		public Guid? ShopId => throw new NotImplementedException();
	}
}
