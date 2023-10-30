namespace CrispChat.Net.Services
{
    public class BaseService
    {
        internal static HttpService httpService { get; set; }

        public BaseService(string tokenIdentifier, string tokenKey)
        {
            httpService = new HttpService(tokenIdentifier, tokenKey);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
