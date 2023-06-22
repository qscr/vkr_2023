using System;
using System.Collections.Generic;
using System.Security.Claims;
using DynamicStore.Api.Core.Abstractions;
using DynamicStore.Api.Core.Entities;
using DynamicStore.Api.Core.Enums;

namespace DynamicStore.Api.Core.Services
{
	/// <inheritdoc/>
	public class ClaimsIdentityFactory : IClaimsIdentityFactory
	{
		/// <inheritdoc/>
		public ClaimsIdentity CreateClaimsIdentity(User? user = default)
		{
			if (user is null)
				throw new ArgumentNullException(nameof(user));

			return new ClaimsIdentity(new List<Claim>
			{
#pragma warning restore CA1304 // Specify CultureInfo
				new(ClaimTypes.NameIdentifier, user?.Id.ToString() ?? string.Empty),
				new(ClaimTypes.Name, user?.Name ?? string.Empty),
				new(ClaimNames.ShopId, user?.ShopId.ToString() ?? string.Empty),
			});
		}
	}
}
