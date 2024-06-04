using System.Net.Http.Headers;

namespace Alura.Adopet.Console.ConfigureHttp
{
    public class PetClientFactory : IHttpClientFactory
    {
        private string _uri = Configuration.UrlAdoPet;
        public HttpClient CreateClient(string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_uri);

            return client;
        }
    }
}