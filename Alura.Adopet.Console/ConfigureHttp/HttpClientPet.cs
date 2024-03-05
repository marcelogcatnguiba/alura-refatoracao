using System.Net.Http.Headers;

namespace Alura.Adopet.Console.ConfigureHttp
{
    public class HttpClientPet
    {
        private readonly HttpClient _client;
        public HttpClient GetClient { get => _client; }
        public HttpClientPet(string uri = "http://localhost:5057")
        {
            _client = ConfiguraHttpClient(uri);
        }
        private HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return client;
        }
    }
}