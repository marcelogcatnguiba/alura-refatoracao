using System.Net.Http.Headers;

namespace Alura.Adopet.Console.ConfigureHttp
{
    public class PetClientFactory
    {
        private const string _uri = "http://localhost:5057";
        private static HttpClient? _client = null;

        public static HttpClient GetHttpClient(string uri = _uri)
        {
            return _client == null ? ConfiguraHttpClient(uri) : _client;
        }

        private static HttpClient ConfiguraHttpClient(string uri)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(uri);

            return client;
        }
    }
}