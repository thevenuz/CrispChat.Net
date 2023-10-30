using CrispChat.Net.Services;

namespace CrispChat.Net
{
    /// <summary>
    /// The client used to interact with Crisp Chat API.
    /// Initializes different services used in the library.
    /// </summary>
    public class CrispClient
    {
        private readonly string _websiteId;
        private readonly string _tokenIdentifier;
        private readonly string _tokenKey;

        #region services
        public WebsiteService WebsiteService { get; set; }
        #endregion

        public CrispClient(string websiteId, string tokenIdentifier, string tokenKey)
        {
            _websiteId = websiteId;
            _tokenIdentifier = tokenIdentifier;
            _tokenKey = tokenKey;
            InitServices();
        }

        private void InitServices()
        {
            this.WebsiteService = new WebsiteService(_websiteId, _tokenIdentifier, _tokenKey);
        }
    }
}
