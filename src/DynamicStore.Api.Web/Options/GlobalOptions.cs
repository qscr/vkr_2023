using System.ComponentModel.DataAnnotations;
using DynamicStore.Api.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace DynamicStore.Api.Web.Options
{
	/// <summary>
	/// Опции приложения
	/// </summary>
	public class GlobalOptions
	{
		public GlobalOptions() => CacheProfiles = new CacheProfileOptions();

		[Required]
		public CacheProfileOptions CacheProfiles { get; }

		public KestrelServerOptions Kestrel { get; set; } = default!;

		[Required]
		public ApplicationOptions Application { get; set; } = default!;

		[Required]
		public CompressionOptions Compression { get; set; } = default!;

		[Required]
		public ForwardedHeadersOptions ForwardedHeaders { get; set; } = default!;

		[Required]
		public AuthenticationTokenOptions Token { get; set; } = default!;

		[Required]
		public FirebaseServiceAccountOptions FirebaseServiceAccount { get; set; } = default!;
	}
}
