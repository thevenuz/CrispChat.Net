using CrispChat.Net.Internal;
using CrispChat.Net.Models;
using CrispChat.Net.Services.IServices;

namespace CrispChat.Net.Services
{
    public class WebsiteService : BaseService, IWebsiteService
    {
        private readonly string _websiteId;
        private readonly Endpoints _endPoints;

        public WebsiteService(string websiteId, string tokenIdentifier, string tokenKey)
            : base(tokenIdentifier, tokenKey)
        {
            _websiteId = websiteId;
            _endPoints = new Endpoints();
        }

        #region conversations
        //public async IList<string> GetConversations() { }
        #endregion

        #region Conversation
        /// <inheritdoc/>
        public async Task<Result<Response<Session>, ErrorResult>> CreateConversationAsync()
        {
            var request = _endPoints.CreateConversation.GenerateRequest(_websiteId);
            return await httpService.RequestAsync<Response<Session>>(request);
        }

        /// <inheritdoc/>
        public async Task<Result<Response, ErrorResult>> CheckIfConversationExistsAsync(
            string sessionId
        )
        {
            var request = _endPoints.CheckIfConversationExists.GenerateRequest(
                _websiteId,
                sessionId
            );
            return await httpService.RequestAsync<Response>(request);
        }

        /// <inheritdoc/>
        public async Task<Result<Response<Conversation>, ErrorResult>> GetConversationAsync(
            string sessionId
        )
        {
            var request = _endPoints.GetConversation.GenerateRequest(_websiteId, sessionId);
            return await httpService.RequestAsync<Response<Conversation>>(request);
        }

        /// <inheritdoc/>
        public async Task<Result<Response, ErrorResult>> RemoveConversationAsync(string sessionId)
        {
            var request = _endPoints.RemoveConversation.GenerateRequest(_websiteId, sessionId);
            return await httpService.RequestAsync<Response>(request);
        }

        /// <inheritdoc/>
        public async Task<Result<Response<IList<Message>>, ErrorResult>> GetMessagesAsync(
            string sessionId
        )
        {
            var request = _endPoints.GetMessages.GenerateRequest(_websiteId, sessionId);
            return await httpService.RequestAsync<Response<IList<Message>>>(request);
        }

        /// <inheritdoc/>
        public Task<Result<string, ErrorResult>> InitiateConversationAsync(string sessionId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<Result<Response<FingerPrint>, ErrorResult>> SendMessageAsync(
            string sessionId,
            MessageBody messageBody
        )
        {
            var request = _endPoints.SendMessage
                .GenerateRequest(_websiteId, sessionId)
                .WithData(messageBody);
            return await httpService.RequestAsync<Response<FingerPrint>>(request);
        }

        /// <inheritdoc/>
        public async Task<Result<Response<Message>, ErrorResult>> GetMessageAsync(
            string sessionId,
            string fingerprint
        )
        {
            var request = _endPoints.GetMessage.GenerateRequest(sessionId, fingerprint);
            return await httpService.RequestAsync<Response<Message>>(request);
        }
        #endregion
    }
}
