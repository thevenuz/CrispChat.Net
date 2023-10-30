using CrispChat.Net.Enums;
using CrispChat.Net.Internal;
using Newtonsoft.Json;
using System.Text.Json;

namespace CrispChat.Net.Models
{
    // TODO: Remove abstract class if not needed in future.
    public abstract class Response { }

    public class Response<T> : Response
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("reason")]
        public string? Reason { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }

    public class Session
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }

    #region Conversation
    public class Conversation
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("website_id")]
        public string WebsiteId { get; set; }

        [JsonProperty("people_id")]
        public string PeopleId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("state")]
        public ConversationState State { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("availability")]
        public VisitorAvailability Availability { get; set; }

        [JsonProperty("active")]
        public Active Active { get; set; }

        [JsonProperty("last_message")]
        public string LastMessage { get; set; }

        [JsonProperty("mentions")]
        public IList<string> Mentions { get; set; }

        [JsonProperty("Participants")]
        public IList<Participants> Participants { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("unread")]
        public Unread Unread { get; set; }

        [JsonProperty("assigned")]
        public Assigned Assigned { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("compose")]
        public Compose Compose { get; set; }
    }

    public class Active
    {
        [JsonProperty("now")]
        public bool Now { get; set; }

        [JsonProperty("last")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? Last { get; set; }
    }

    public class Participants
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    public class Unread
    {
        [JsonProperty("operator")]
        public int Operator { get; set; }

        [JsonProperty("visitor")]
        public int Visitor { get; set; }
    }

    public class Assigned
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public class Meta
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; } //TODO: check the actual type

        [JsonProperty("device")]
        public Device Device { get; set; }

        [JsonProperty("segments")]
        public IList<string> Segments { get; set; }
    }

    public class Device
    {
        [JsonProperty("capabilities")]
        public VisitorDeviceCapabilities? Capabilities { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("system")]
        public System System { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("locales")]
        public IList<string> Locales { get; set; }
    }

    public class Geolocation
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class System
    {
        [JsonProperty("os")]
        public Os Os { get; set; }

        [JsonProperty("engine")]
        public Engine Engine { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }

        [JsonProperty("useragent")]
        public string Useragent { get; set; }
    }

    public class Os
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Engine
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Browser
    {
        [JsonProperty("major")]
        public string Major { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Compose
    {
        [JsonProperty("operator")]
        public IDictionary<string, Operator> Operator { get; set; }
    }

    public class Operator
    {
        [JsonProperty("type")]
        public ComposeStateType Type { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    //TODO: remove duplicate between opertaor and visitor
    public class Visitor
    {
        [JsonProperty("type")]
        public ComposeStateType Type { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? Timestamp { get; set; }
    }

    public class Message
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("website_id")]
        public string WebsiteId { get; set; }

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
        /// The preview of the URLs contained in the message.
        /// </summary>
        [JsonProperty("preview")]
        public IList<MessagePreview> MessagePreview { get; set; }

        /// <summary>
        /// Indicated whether the message was fully processed in the internal Crisp pipeline.
        /// </summary>
        [JsonProperty("stamped")]
        public bool Stamped { get; set; }

        /// <summary>
        /// Indicates whether message was edited after being sent or not.
        /// </summary>
        [JsonProperty("edited")]
        public bool Edited { get; set; }

        /// <summary>
        /// Indicates whether message was auto-translated or not.
        /// </summary>
        [JsonProperty(("translated"))]
        public bool Translated { get; set; }

        /// <summary>
        /// List of mentioned user identifiers.
        /// </summary>
        [JsonProperty("mentions")]
        public IList<string> Mentions { get; set; }

        /// <summary>
        /// The channel in which message has been read.
        /// </summary>
        [JsonProperty("read")]
        public MessageChannels ChannelRead { get; set; }

        /// <summary>
        /// The channel in which message has been delivered.
        /// </summary>
        [JsonProperty("delivered")]
        public MessageChannels ChannelDelivered { get; set; }

        /// <summary>
        /// The unique message fingerprint.
        /// </summary>
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        /// <summary>
        /// The time at which the message was sent.
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(JsonDateTimeMillisecondsConverter))]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The sending user information.
        /// </summary>
        [JsonProperty("user")]
        public MessageUser User { get; set; }

        /// <summary>
        /// The original message data.
        /// </summary>
        [JsonProperty("original")]
        public Original Original { get; set; }
    }

    public class MessageContentData
    {
        /// <summary>
        /// This will be set only when the message type is <c>text</c> or <c>note</c>.
        /// </summary>
        public string Textdata { get; set; }

        /// <summary>
        /// This will be set only when the message type is <c>file</c>, <c>animation</c>, <c>audio</c>,<c>picker</c>, <c>field</c>, <c>carousel</c> or <c>event</c>.
        /// </summary>
        public MessageContent? MessageContent { get; set; }
    }

    public class MessageContent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("explain")]
        public string Explain { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// The Choices. This will be set only when the message type is <c>picker</c>.
        /// </summary>
        [JsonProperty("choices")]
        public IList<MessageContentPickerChoices> Choices { get; set; }

        /// <summary>
        /// The targets. This will be set only when the message type is <c>carousel</c>.
        /// </summary>
        [JsonProperty("targets")]
        public IList<MessageContentTarget> Targets { get; set; }

        /// <summary>
        /// The name of the file. This will be set only when the message type is <c>file</c>.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The duration of the audio in seconds. This will be set only when the message type is <c>audio</c>.
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// The URL of the file. This will be set only when the message type is <c>file</c>, <c>animation</c> or <c>audio</c>.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The MIME type. This will be set only when the message type is <c>file</c>, <c>animation</c> or <c>audio</c>.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The event namespace. This will be set only when the message type is <c>event</c>.
        /// </summary>
        [JsonProperty("namespace")]
        public EventNamespace Namespace { get; set; }

        /// <summary>
        /// This indicates if message must be filled before continuing. This will be set only if message type is <c>picker</c> or <c>field</c>.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }
    }

    public class MessageContentPickerChoices
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("action")]
        public MessageContentChoiceAction Actions { get; set; }
    }

    public class MessageContentTarget
    {
        /// <summary>
        /// The title of the target.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of the target.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The banner image url of the target.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// The target action buttons.
        /// </summary>
        [JsonProperty("actions")]
        public IList<MessageTargetsActions> Actions { get; set; }
    }

    public class MessageTargetsActions
    {
        /// <summary>
        /// Action label.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Action link URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class MessageContentChoiceAction
    {
        [JsonProperty("type")]
        public MessageChoiceActionType Type { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    public class MessagePreview
    {
        /// <summary>
        /// The preview URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The website domain for the previewed URL.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// The page title for the previewed URL.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The preview information.
        /// </summary>
        [JsonProperty("preview")]
        public MessagePreviewInfo PreviewInfo { get; set; }
    }

    public class MessagePreviewInfo
    {
        /// <summary>
        /// The text excerpt from the page.
        /// </summary>
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        /// <summary>
        /// The main image from the page.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// The embeddable frame of the main page.
        /// </summary>
        [JsonProperty("embed")]
        public string Embed { get; set; }
    }

    //TODO: Check if User class is available.
    /// <summary>
    /// The sending user information.
    /// </summary>
    public class MessageUser
    {
        /// <summary>
        /// The sending user type.
        /// </summary>
        [JsonProperty("type")]
        public UserType UserType { get; set; }

        /// <summary>
        /// The sending user identifier - operator user identifier or session identifier.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

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

    /// <summary>
    /// The original message data.
    /// </summary>
    public class Original
    {
        /// <summary>
        /// The original message identifier.
        /// </summary>
        [JsonProperty("original_id")]
        public string OriginalId { get; set; }
    }

    public class FingerPrint
    {
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }
    }

    #endregion
}
