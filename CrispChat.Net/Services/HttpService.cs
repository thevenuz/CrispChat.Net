using System.Text;
using CrispChat.Net.Services.IServices;
using CrispChat.Net.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;

namespace CrispChat.Net.Services
{
    /// <summary>
    /// Contains HTTP client that makes actual calls to the API.
    /// </summary>
    internal class HttpService : IHttpService, IDisposable
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static IList<HttpStatusCode> _successStatusCodes;
        private static string _authToken;
        private static Dictionary<string, string> _defaultHeaders;
        private bool _isDisposed;

        public HttpService(string tokenIdentifier, string tokenKey)
        {
            _authToken = GetAuthToken(tokenIdentifier, tokenKey);
            _defaultHeaders = GetHeaders();

            _successStatusCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Created,
                HttpStatusCode.Accepted
            };
        }

        /// <summary>
        /// Handles the actual request to the CRISP API.
        /// </summary>
        /// <typeparam name="T">Result</typeparam>
        /// <param name="request">The <see cref="Request"/> object.</param>
        /// <returns>This method returns an object of type <see cref="Result{Response}"/>.</returns>
        public async Task<Result<T, ErrorResult>> RequestAsync<T>(Request request)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(request.Method, request.Uri))
                {
                    SetHeader(requestMessage, "X-Crisp-Tier", request.Tier);
                    SetHeaders(requestMessage);

                    if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Patch)
                        SetContent(requestMessage, request.Data);

                    var response = await _httpClient
                        .SendAsync(requestMessage)
                        .ConfigureAwait(false);

                    if (_successStatusCodes.Contains(response.StatusCode))
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        return responseData == null
                            ? new Result<T, ErrorResult>().Ok(default(T))
                            : new Result<T, ErrorResult>().Ok(
                                JsonConvert.DeserializeObject<T>(responseData)
                            );
                    }

                    //return new Result<T, E>((int)response.StatusCode, response.ReasonPhrase);


                    return new Result<T, ErrorResult>().Err(
                        new ErrorResult((int)response.StatusCode, response.ReasonPhrase ?? "")
                    );
                }
            }
            catch (Exception ex)
            {
                //return new ErrorResult<Exception>("Exception occured.", ex);
                return new Result<T, ErrorResult>().Err(
                    new ErrorResult(500, "Exception occured.", ex)
                );
            }
        }

        /// <summary>
        /// Sets common headers to the request.
        /// </summary>
        /// <param name="requestMessage"></param>
        private void SetHeaders(HttpRequestMessage requestMessage)
        {
            _httpClient.DefaultRequestHeaders.Clear();

            foreach (var item in _defaultHeaders)
                SetHeader(requestMessage, item.Key, item.Value);
        }

        /// <summary>
        /// Sets content required in PUT, POST etc. methods to the request.
        /// </summary>
        /// <param name="requestMessage">The request message object.</param>
        /// <param name="content"></param>
        private void SetContent(HttpRequestMessage requestMessage, object content)
        {
            requestMessage.Content = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json"
            );
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(
                "application/json"
            );
        }

        /// <summary>
        /// Builds the AuthToken using token identifier and token key.
        /// </summary>
        /// <param name="tokenIdentifier"></param>
        /// <param name="tokenKey"></param>
        /// <returns>
        /// Returns the AuthToken which can be sent in headers.
        /// </returns>
        private string GetAuthToken(string tokenIdentifier, string tokenKey) =>
            $"Basic {Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{tokenIdentifier}:{tokenKey}"))}";

        /// <summary>
        /// Get default common headers.
        /// </summary>
        /// <returns>
        /// A dictionary which contains common headers.
        /// </returns>
        private Dictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            headers.Add("Authorization", _authToken);
            return headers;
        }

        /// <summary>
        /// Sets the individual header on the request.
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void SetHeader(HttpRequestMessage requestMessage, string key, string value)
        {
            requestMessage.Headers.Add(key, value);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    _httpClient.Dispose();
                _isDisposed = true;
            }
        }
    }
}
