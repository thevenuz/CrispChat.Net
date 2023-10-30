using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace CrispChat.Net.Enums
{
    public enum ConversationState
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "unresolved")]
        Unresolved,

        [EnumMember(Value = "resolved")]
        Resolved
    }

    public enum VisitorAvailability
    {
        [EnumMember(Value = "online")]
        Online,

        [EnumMember(Value = "offline")]
        Offline
    }

    /// <summary>
    /// For opertaor.
    /// </summary>
    public enum ComposeStateType
    {
        [EnumMember(Value = "start")]
        Start,

        [EnumMember(Value = "stop")]
        Stop,
    }

    public enum VisitorDeviceCapabilities
    {
        //[EnumMember(Value = "")]
        //NotSet,

        [EnumMember(Value = "browsing")]
        Browsing,

        [EnumMember(Value = "call")]
        Call
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "note")]
        Note,

        [EnumMember(Value = "file")]
        File,

        [EnumMember(Value = "animation")]
        Animation,

        [EnumMember(Value = "audio")]
        Audio,

        [EnumMember(Value = "picker")]
        Picker,

        [EnumMember(Value = "field")]
        Field,

        [EnumMember(Value = "carousel")]
        Carousel,

        [EnumMember(Value = "event")]
        Event
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageFrom
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "operator")]
        Operator
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageOrigin
    {
        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "urn:*")]
        Urn
    }

    public enum MessageChoiceActionType
    {
        [EnumMember(Value = "frame")]
        Frame,

        [EnumMember(Value = "link")]
        Link
    }

    public enum EventNamespace
    {
        [EnumMember(Value = "state:resolved")]
        StateResolved,

        [EnumMember(Value = "user:blocked")]
        UserBlocked,

        [EnumMember(Value = "reminder:scheduled")]
        ReminderScheduled,

        [EnumMember(Value = "thread:started")]
        ThreadStarted,

        [EnumMember(Value = "thread:ended")]
        threadEnded,

        [EnumMember(Value = "participant:added")]
        ParticipantAdded,

        [EnumMember(Value = "participant:removed")]
        ParticipantRemoved,

        [EnumMember(Value = "call:started")]
        CallStarted,

        [EnumMember(Value = "call:ended")]
        CallEnded
    }

    /// <summary>
    /// Enum for different channels available.
    /// </summary>
    public enum MessageChannels
    {
        [EnumMember(Value = "")]
        NotSet,

        [EnumMember(Value = "chat")]
        Chat,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "urn:*")]
        Urn
    }

    /// <summary>
    /// The user type of the message.
    /// </summary>
    public enum UserType
    {
        [EnumMember(Value = "")]
        NotSet,

        [EnumMember(Value = "website")]
        Website,

        [EnumMember(Value = "participant")]
        Participant
    }

    public enum OriginalMessageType
    {
        [EnumMember(Value = "text")]
        Text,

        [EnumMember(Value = "html")]
        Html
    }
}
