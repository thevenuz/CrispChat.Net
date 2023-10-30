using CrispChat.Net.Models;

namespace CrispChat.Net.Internal
{
    internal class Endpoints
    {
        private const string BASE_URL = "https://api.crisp.chat/v1";
        private const string WEBSITE_URL = $"{BASE_URL}/website";

        internal string ConversationUrl = $"{WEBSITE_URL}/()/conversation";
        #region Website
        public Request CheckWebsiteExists => BuildRequest(WEBSITE_URL, HttpMethod.Head);
        public Request CreateWebsite => BuildRequest(WEBSITE_URL, HttpMethod.Post, "user");
        public Request GetWebsite => BuildRequest($"{WEBSITE_URL}/()", HttpMethod.Get);

        #region Conversations
        // Args: website_id, page_number
        public Request GetConversations =>
            BuildRequest($"{WEBSITE_URL}/()/conversations/()", HttpMethod.Get);

        // Args: website_id, page_number
        public Request GetSuggestedConversationSegments =>
            BuildRequest($"{WEBSITE_URL}/()/conversations/suggest/segments/()", HttpMethod.Get);

        // Args: website_id
        public Request DeleteSuggestedConversationSegment =>
            BuildRequest($"{WEBSITE_URL}/()/conversations/suggest/segment", HttpMethod.Delete);

        // Args: website_id, page_number
        public Request GetSuggestedConversationDataKeys =>
            BuildRequest($"{WEBSITE_URL}/()/conversations/suggest/data/()", HttpMethod.Get);

        // Args: website_id
        public Request DeleteSuggestedConversationDataKey =>
            BuildRequest($"{WEBSITE_URL}/()/conversations/suggest/data", HttpMethod.Delete);

        #endregion


        #region Conversation


        /// <summary>
        /// Args: website_id
        /// </summary>
        public Request CreateConversation => BuildRequest(ConversationUrl, HttpMethod.Post);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request CheckIfConversationExists =>
            BuildRequest($"{ConversationUrl}/()", HttpMethod.Head);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetConversation => BuildRequest($"{ConversationUrl}/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request RemoveConversation =>
            BuildRequest($"{ConversationUrl}/()", HttpMethod.Delete);

        /// <summary>
        /// Initiate A Conversation With Existing Session
        /// Args: website_id, session_id
        /// </summary>
        public Request ReinitiateConversation =>
            BuildRequest($"{ConversationUrl}/()/initiate", HttpMethod.Post);

        /// <summary>
        /// Args: website_id, session_id
        /// params: timestamp_before
        /// </summary>
        public Request GetMessages =>
            BuildRequest($"{ConversationUrl}/()/messages", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts post data.
        /// </summary>
        public Request SendMessage =>
            BuildRequest($"{ConversationUrl}/()/message", HttpMethod.Post);

        /// <summary>
        /// Args: website_id, session_id, fingerprint
        /// </summary>
        public Request GetMessage =>
            BuildRequest($"{ConversationUrl}/()/message/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id, fingerprint
        /// Accepts post data.
        /// </summary>
        public Request UpdateMessage =>
            BuildRequest($"{ConversationUrl}/()/message/()", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id, fingerprint
        /// </summary>
        public Request RemoveMessage =>
            BuildRequest($"{ConversationUrl}/()/message/()", HttpMethod.Delete);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts post data.
        /// </summary>
        public Request ComposeMessage =>
            BuildRequest($"{ConversationUrl}/()/compose", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts post data.
        /// </summary>
        public Request MarkMessagesAsRead =>
            BuildRequest($"{ConversationUrl}/()/read", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts post data.
        /// </summary>
        public Request MarkMessagesAsDelivered =>
            BuildRequest($"{ConversationUrl}/()/delivered", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts post data.
        /// </summary>
        public Request UpdateConversationOpenState =>
            BuildRequest($"{ConversationUrl}/()/open", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetConversationRoutingAssign =>
            BuildRequest($"{ConversationUrl}/()/routing", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts data.
        /// </summary>
        public Request AssignConversationRouting =>
            BuildRequest($"{ConversationUrl}/()/routing", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetConversationMetas =>
            BuildRequest($"{ConversationUrl}/()/meta", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts data.
        /// </summary>
        public Request UpdateConversationMetas =>
            BuildRequest($"{ConversationUrl}/()/meta", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id, original_id
        /// </summary>
        public Request GetOriginalMessage =>
            BuildRequest($"{ConversationUrl}/()/original/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id, page_number
        /// </summary>
        public Request GetConversationByPage =>
            BuildRequest($"{ConversationUrl}/()/pages/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id, page_number
        /// </summary>
        public Request GetConversationEvents =>
            BuildRequest($"{ConversationUrl}/()/events/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id, page_number
        /// </summary>
        public Request GetConversationFiles =>
            BuildRequest($"{ConversationUrl}/()/files/()", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetConversationState =>
            BuildRequest($"{ConversationUrl}/()/state", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts data.
        /// </summary>
        public Request ChangeConversationState =>
            BuildRequest($"{ConversationUrl}/()/state", HttpMethod.Patch);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetConversationParticipants =>
            BuildRequest($"{ConversationUrl}/()/participants", HttpMethod.Get);

        /// <summary>
        /// Args: website_id, session_id
        /// Accepts data.
        /// </summary>
        public Request SaveConversationParticipants =>
            BuildRequest($"{ConversationUrl}/()/participants", HttpMethod.Put);

        /// <summary>
        /// Args: website_id, session_id
        /// </summary>
        public Request GetBlockStatusForConversation =>
            BuildRequest($"{ConversationUrl}/()/block", HttpMethod.Get);

        #endregion

        #endregion

        private Request BuildRequest(string url, HttpMethod method) => new Request(url, method);

        private Request BuildRequest(string url, HttpMethod method, string tier) =>
            new Request(url, method, tier);
    }
}
