using CrispChat.Net.Models;

namespace CrispChat.Net.Services.IServices
{
    public interface IWebsiteService
    {
        /// <summary>
        /// Creates a new conversation. But this conversation will not be visible in the Crisp inbox until a message is sent.
        /// </summary>
        /// <returns>This method returns an object of type <see cref="Result{Response{Session},ErrorResult}"/>.</returns>
        Task<Result<Response<Session>, ErrorResult>> CreateConversationAsync();

        /// <summary>
        /// Checks if a conversatin with provided session id exists or not.
        /// </summary>
        /// <param name="sessionId">The session id of the conversation.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response,ErrorResult}"/>.</returns>
        Task<Result<Response, ErrorResult>> CheckIfConversationExistsAsync(string sessionId);

        /// <summary>
        /// Gets a conversation details with provided session id.
        /// </summary>
        /// <param name="sessionId">The session id of the conversation.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response{Conversation}, ErrorResult}"/>.</returns>
        Task<Result<Response<Conversation>, ErrorResult>> GetConversationAsync(string sessionId);

        /// <summary>
        /// Removes a conversation with provided session id.
        /// </summary>
        /// <param name="sessionId">The session id of the conversation.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response,ErrorResult}"/>.</returns>
        Task<Result<Response, ErrorResult>> RemoveConversationAsync(string sessionId);

        /// <summary>
        /// Initiates a conversation from an existing session.
        /// </summary>
        /// <param name="sessionId">The session id of the conversation.</param>
        /// <returns>This method returns an object of type <see cref="Result{String,ErrorResult}"/>.</returns>
        Task<Result<string, ErrorResult>> InitiateConversationAsync(string sessionId);

        /// <summary>
        /// Gets messages from a conversation with provided session id and timestamp.
        /// </summary>
        /// <param name="sessionId">The session id of the converstaion.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response{IList{Message}},ErrorResult}"/></returns>
        Task<Result<Response<IList<Message>>, ErrorResult>> GetMessagesAsync(string sessionId);

        /// <summary>
        /// Sends a message in an existing conversation.
        /// </summary>
        /// <param name="sessionId">The session Id of the existing coverstaion.</param>
        /// <param name="messageBody">The body of the message to be sent.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response{FingerPrint}, ErrorResult}"/></returns>
        Task<Result<Response<FingerPrint>, ErrorResult>> SendMessageAsync(
            string sessionId,
            MessageBody messageBody
        );

        /// <summary>
        /// Get a message with provided session id and fingerprint.
        /// </summary>
        /// <param name="sessionId">The session Id of the conversation.</param>
        /// <param name="fingerprint">The message fingerprint.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response{Message}, ErrorResult}"/></returns>
        Task<Result<Response<Message>, ErrorResult>> GetMessageAsync(
            string sessionId,
            string fingerprint
        );
    }
}
