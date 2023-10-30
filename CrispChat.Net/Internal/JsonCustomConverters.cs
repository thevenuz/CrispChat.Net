using CrispChat.Net.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CrispChat.Net.Internal
{
    internal class JsonDateTimeMillisecondsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            var t = long.Parse(reader.Value.ToString());
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var valueDto = (DateTimeOffset)(DateTime)value;
            var milliseconds = (valueDto).ToUnixTimeMilliseconds();
            writer.WriteValue(milliseconds);
        }
    }

    /// <summary>
    /// This converter converts a <see cref="DateTime"/> object to unix timestamp in milliseconds.
    /// </summary>
    internal class JsonDateTimeToUnixConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            var t = DateTimeOffset.Parse(reader.Value.ToString());
            return t.ToUnixTimeMilliseconds();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Customer converter to desrialize message content data. Deserializes to either <see cref="MessageContent"/> or <see cref="string"/>.
    /// </summary>
    internal class JsonMessageContentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            var jo = JToken.Load(reader);
            var messageContentData = new MessageContentData();
            if (jo.Type == JTokenType.String)
                messageContentData.Textdata = jo.Value<string>();
            else
                messageContentData.MessageContent = jo.ToObject<MessageContent>();

            return messageContentData;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var valueDto = value as MessageContentData;

            if (valueDto.Textdata != null)
                writer.WriteValue(valueDto.Textdata);
            else
                writer.WriteValue(valueDto.MessageContent);
        }
    }
}
