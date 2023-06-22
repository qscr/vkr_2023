using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicStore.Api.Client.Converters
{
	/// <summary>
	/// Конвертер для JsonDocument без RootElement повсюду
	/// </summary>
	internal sealed class JsonDocumentConverter : JsonConverter<JsonDocument>
	{
		/// <inheritdoc/>
		public override JsonDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> JsonDocument.ParseValue(ref reader);

		/// <inheritdoc/>
		public override void Write(Utf8JsonWriter writer, JsonDocument value, JsonSerializerOptions options)
			=> value?.RootElement.WriteTo(writer);
	}
}
