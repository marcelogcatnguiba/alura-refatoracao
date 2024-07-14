using System.Net.Http.Json;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.ConfigureHttp
{
    public class PetService(HttpClient client) : IAPIService<Pet>
    {
        private readonly HttpClient _client = client;
        
        public virtual async Task CreatePetAsync(Pet pet)
        { 
            await _client.PostAsJsonAsync("pet/add", pet); 
        }

        public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}