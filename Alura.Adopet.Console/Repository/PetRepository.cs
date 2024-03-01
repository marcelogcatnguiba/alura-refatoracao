using System.Net.Http.Json;
using Alura.Adopet.Console.ConfigureHttp;

namespace Alura.Adopet.Console.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly HttpClient _client;
        public PetRepository()
        {
            var clientPet = new HttpClientPet();
            _client = clientPet.GetClient;
        }

        public async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return await _client.PostAsJsonAsync("pet/add", pet);
            }
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}