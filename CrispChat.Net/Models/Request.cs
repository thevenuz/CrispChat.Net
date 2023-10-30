using System.Text.RegularExpressions;

namespace CrispChat.Net.Models
{
    internal class Request
    {
        public string Uri { get; set; }
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public string Tier { get; set; } = "plugin";

        public object? Data { get; set; }

        public Request(string uri, HttpMethod method)
        {
            Uri = uri;
            Method = method;
        }

        public Request(string uri, HttpMethod method, string tier)
        {
            Uri = uri;
            Method = method;
            Tier = tier;
        }

        public Request GenerateRequest(params string[] args)
        {
            var regex = new Regex(Regex.Escape("()"));
            foreach (var arg in args)
            {
                Uri = regex.Replace(Uri, arg, 1);
            }
            return this;
        }

        public Request WithParams(Dictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                var queryParams = new FormUrlEncodedContent(parameters);
                Uri = $"{Uri}?{queryParams.ReadAsStringAsync().Result}";
            }
            return this;
        }

        /// <summary>
        /// Sets the body to be sent with the request.
        /// </summary>
        /// <param name="data">Any object that need to be passed along with the request.</param>

        public Request WithData(object data)
        {
            Data = data;
            return this;
        }
    }
}
