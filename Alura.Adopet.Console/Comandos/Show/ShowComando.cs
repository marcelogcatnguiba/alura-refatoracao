using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Show
{
    public class ShowComando<T>(ILeitor<T> leitorArquivo) : IComando
    {
        private readonly ILeitor<T> _leitorDeArquivo = leitorArquivo;

        public async Task<Result> ExecutarComando()
        {
            return await ListarEntidadesDeArquivo();
        }

        public Task<Result> ListarEntidadesDeArquivo()
        {
            try
            {
                var lista = _leitorDeArquivo.RealizarLeitura();
                return Task.FromResult(Result.Ok().WithSuccess(new SuccessShow<T>(lista)));
            }
            catch(Exception e)
            {
                return Task.FromResult(Result.Fail(new Error("Falha ao listar").CausedBy(e)));
            }
            
        }
    }
}