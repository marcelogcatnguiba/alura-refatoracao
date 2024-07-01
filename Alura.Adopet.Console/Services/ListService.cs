using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListService : IComando
    {
        private readonly HttpClientPet _client;
        
        public ListService(HttpClientPet client)
        {
            _client = client;
        }

        public async Task<Result> ExecutarComando(string[] args)
        {
            return await ListarPetsCadastrados();
        }

        private async Task<Result> ListarPetsCadastrados()
        {
            var listPets = await _client.ListPetsAsync();
            
            foreach (var p in listPets!)
                System.Console.WriteLine(p);

            return Result.Ok();
        }
    }
}