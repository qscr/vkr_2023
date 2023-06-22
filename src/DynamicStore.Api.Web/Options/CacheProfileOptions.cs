using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Api.Web.Options
{
	/// <summary>
	/// Опции кэширования http
	/// </summary>
	public class CacheProfileOptions : Dictionary<string, CacheProfile>
	{
	}
}
