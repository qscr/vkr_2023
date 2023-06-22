using System.Collections.Generic;

namespace DynamicStore.Api.Web.Options
{
	/// <summary>
	/// Опции сжатия динамического ответа
	/// </summary>
	public class CompressionOptions
	{
		public CompressionOptions()
			=> MimeTypes = new List<string>();

		/// <summary>
		/// Типы контента для сжатия
		/// </summary>
		public List<string> MimeTypes { get; }
	}
}
