using System;
using System.IO;

namespace DynamicStore.Api.Core.Extensions
{
	/// <summary>
	/// Расширения для <see cref="Stream"/>
	/// </summary>
	public static class StreamExtensions
	{
		/// <summary>
		/// Конвертировать поток в массив байтов
		/// </summary>
		/// <param name="stream">Поток</param>
		/// <returns>Массив байтов</returns>
		public static byte[] ToByteArray(this Stream stream)
		{
			if (stream is null)
				throw new ArgumentNullException(nameof(stream));

			var buffer = new byte[stream.Length];
			for (var totalBytesCopied = 0; totalBytesCopied < stream.Length;)
				totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
			return buffer;
		}
	}
}
