using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListComando : IComando
    {
        private readonly IAPIService<Pet> _client;
        
        public ListComando(IAPIService<Pet> client)
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