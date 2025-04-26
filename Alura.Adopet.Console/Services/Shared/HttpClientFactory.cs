using System.Net.Http.Headers;

namespace Alura.Adopet.Console.Services.Shared
{
    public class HttpClientFactory(string uri) : IHttpClientFactory
    {
        private readonly string _uri = uri;
        public HttpClient CreateClient(string name)
        {
            HttpClient client = new ();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_uri);

            return client;
        }
    }
}