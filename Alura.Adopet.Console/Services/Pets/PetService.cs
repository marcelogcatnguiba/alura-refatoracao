using System.Net.Http.Json;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Services.Pets
{
    public class PetService(HttpClient client) : IApiService<Pet>
    {
        private readonly HttpClient _client = client;
        
        public virtual async Task CreateAsync(Pet pet)
        { 
            await _client.PostAsJsonAsync("pet/add", pet); 
        }

        public virtual async Task<IEnumerable<Pet>?> ListAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}