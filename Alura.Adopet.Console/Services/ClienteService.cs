using System.Net.Http.Json;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Services
{
    public class ClienteService(HttpClient client) : IAPIService<Cliente>
    {
        private readonly HttpClient _client = client;

        public virtual async Task CreatePetAsync(Cliente cliente)
        {
            await _client.PostAsJsonAsync("cliente/add", cliente);
        }

        public virtual async Task<IEnumerable<Cliente>?> ListPetsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("cliente/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }
    }
}