using System.Net.Http.Json;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.ConfigureHttp
{
    public class HttpClientPet : IAPIService
    {
        private readonly HttpClient _client;
        public HttpClientPet(HttpClient client)
        {
            _client = client;
        }

        public virtual async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return await _client.PostAsJsonAsync("pet/add", pet);
            }
        }
        public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}