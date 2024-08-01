using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.List
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
                var listPets = await _client.ListAsync();
                return Result.Ok().WithSuccess(new SuccessList(listPets!));
            }
            catch(Exception ex)
            {
                return Result.Fail(new Error("Erro ao listar pets").CausedBy(ex));
            }
        }
    }
}