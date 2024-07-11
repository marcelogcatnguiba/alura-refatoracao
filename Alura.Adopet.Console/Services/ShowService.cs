using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Documentation;
using FluentResults;
using Alura.Adopet.Console.Readers;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("show", "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowService : IComando
    {
        private readonly LeitorCSV _leitorDeArquivo;

        public ShowService(LeitorCSV leitorArquivo)
        {
            _leitorDeArquivo = leitorArquivo;
        }
        
        public async Task<Result> ExecutarComando()
        {
            return await ListarPetsDeArquivo();
        }

        public Task<Result> ListarPetsDeArquivo()
        {
            try
            {
                var listaDePet = _leitorDeArquivo.RealizarLeitura();
                return Task.FromResult(Result.Ok().WithSuccess(new SuccessShow(listaDePet)));
            }
            catch(Exception e)
            {
                return Task.FromResult(Result.Fail(new Error("Falha ao listar").CausedBy(e)));
            }
            
        }
    }
}