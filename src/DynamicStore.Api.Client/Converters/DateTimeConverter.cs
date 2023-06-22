using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicStore.Api.Client.Converters
{
	/// <summary>
	/// Конвертер для даты и времени
	/// </summary>
	internal sealed class DateTimeConverter : JsonConverter<DateTime>
	{
		/// <inheritdoc/>
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (DateTime.TryParse(reader.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var value))
				return value;
			else
				throw new ArgumentException("Дата имеет неверный формат");
		}

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
			=> writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
	}
}
