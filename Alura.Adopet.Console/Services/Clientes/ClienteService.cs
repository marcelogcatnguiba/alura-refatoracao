using System.Net.Http.Json;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Services.Clientes
{
    public class ClienteService(HttpClient client) : IApiService<Cliente>
    {
        private readonly HttpClient _client = client;

        public virtual async Task CreateAsync(Cliente cliente)
        {
            await _client.PostAsJsonAsync("proprietario/add", cliente);
        }

        public virtual async Task<IEnumerable<Cliente>?> ListAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("proprietario/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }
    }
}