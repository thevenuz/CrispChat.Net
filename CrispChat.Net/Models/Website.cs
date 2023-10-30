using CrispChat.Net.Enums;
using CrispChat.Net.Internal;
using Newtonsoft.Json;

namespace CrispChat.Net.Models
{
    public class Website { }

    /// Message body request - temporary. TODO: move to separate class.
    public class MessageBody
    {
        [JsonProperty("type")]
        public MessageType MessageType { get; set; }

        [JsonProperty("from")]
        public MessageFrom MessageFrom { get; set; }

        [JsonProperty("origin")]
        public MessageOrigin MessageOrigin { get; set; }

        /// <summary>
        /// The contents of the message.
        /// </summary>
        [JsonProperty("content")]
        [JsonConverter(typeof(JsonMessageContentConverter))]
        public MessageContentData MessageContentData { get; set; }

        /// <summary>
        /// Mentioned user identifiers.
        /// </summary>
        [JsonProperty("mentions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IList<string>? Mentions { get; set; }

        /// <summary>
        /// Unique message fingerprint.
        /// </summary>
        [JsonProperty("fingerprint", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Fingerprint { get; set; }

        /// <summary>
        /// The sending user information.
        /// </summary>
        [JsonProperty("user", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public UserBody? User { get; set; }

        /// <summary>
        /// The original message information.
        /// </summary>
        [JsonProperty("original", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OriginalMessageBody? OriginalMessage { get; set; }

        /// <summary>
        /// The timestamp at which the message was sent, in milliseconds.
        /// </summary>
        [JsonProperty("timestamp", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(JsonDateTimeToUnixConverter))]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Message stealth mode (ie. do not propagate message to the other party).
        /// </summary>
        [JsonProperty("stealth", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Stealth { get; set; }

        /// <summary>
        /// Whether message was auto-translated or not
        /// </summary>
        [JsonProperty("translated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? Translated { get; set; }
    }

    public class UserBody
    {
        /// <summary>
        /// The sending user type.
        /// </summary>
        [JsonProperty("type")]
        public UserType UserType { get; set; }

        /// <summary>
        /// The sending user nickname.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// The sending user avatar.
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    public class OriginalMessageBody
    {
        /// <summary>
        /// The original message data MIME type.
        /// </summary>
        [JsonProperty("type")]
        public OriginalMessageType OriginalMessageType { get; set; }

        /// <summary>
        /// The original message data content.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
