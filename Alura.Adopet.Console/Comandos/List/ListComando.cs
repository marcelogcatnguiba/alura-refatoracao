using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Services.Interfaces;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.List
{
    public class ListComando<T>(IApiService<T> service) : IComando
    {
        private readonly IApiService<T> _service = service;

        public async Task<Result> ExecutarComando()
        {
            return await ListarEntidadesCadastradas();
        }

        private async Task<Result> ListarEntidadesCadastradas()
        {
            try
            {
                var lista = await _service.ListAsync();
                return Result.Ok().WithSuccess(new SuccessList<T>(lista!));
            }
            catch(Exception ex)
            {
                return Result.Fail(new Error("Erro ao listar objetos").CausedBy(ex));
            }
        }
    }
}