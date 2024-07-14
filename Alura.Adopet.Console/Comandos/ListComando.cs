using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListComando : IComando
    {
        private readonly HttpClientPet _client;
        
        public ListComando(HttpClientPet client)
        {
            _client = client;
        }

        public async Task<Result> ExecutarComando()
        {
            return await ListarPetsCadastrados();
        }

        private async Task<Result> ListarPetsCadastrados()
        {
            try
            {
                var listPets = await _client.ListPetsAsync();
                return Result.Ok().WithSuccess(new SuccessList(listPets!));
            }
            catch(Exception ex)
            {
                return Result.Fail(new Error("Erro ao listar pets").CausedBy(ex));
            }
        }
    }
}