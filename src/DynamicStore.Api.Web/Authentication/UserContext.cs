using System;
using System.Security.Claims;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace DynamicStore.Api.Web.Authentication
{
	/// <inheritdoc/>
	public class UserContext : IUserContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="httpContextAccessor">Адаптер Http-context'а</param>
		public UserContext(IHttpContextAccessor httpContextAccessor)
			=> _httpContextAccessor = httpContextAccessor;

		/// <inheritdoc/>
		public Guid CurrentUserId => Guid.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
			? userId
			: Guid.Empty;

		/// <inheritdoc/>
		public string UserName => User?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;

		/// <inheritdoc/>
		public Guid? ShopId => Guid.TryParse(User?.FindFirst(ClaimNames.ShopId)?.Value, out var shopId)
			? shopId
			: default;

		private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
	}
}
