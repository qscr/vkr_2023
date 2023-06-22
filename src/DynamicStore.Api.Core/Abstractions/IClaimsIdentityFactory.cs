using System.Security.Claims;
using DynamicStore.Api.Core.Entities;

namespace DynamicStore.Api.Core.Abstractions
{
	/// <summary>
	/// Фабрика ClaimsPrincipal для пользователей.
	/// </summary>
	public interface IClaimsIdentityFactory
	{
		/// <summary>
		/// Создать ClaimsIdentity по данным пользователя.
		/// </summary>
		/// <param name="user">Пользователь</param>
		/// <returns>ClaimsIdentity.</returns>
		ClaimsIdentity CreateClaimsIdentity(User? user = default);
	}
}
