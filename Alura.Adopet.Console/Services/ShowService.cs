using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("show", "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowService : IComando
    {
        private readonly LeitorArquivo _leitorDeArquivo;

        public ShowService(LeitorArquivo leitorArquivo)
        {
            _leitorDeArquivo = leitorArquivo;
        }
        
        public async Task<Result> ExecutarComando(string[] args)
        {
            return await ListarPetsDeArquivo(caminhoDoArquivo: args[1]);
        }

        public Task<Result> ListarPetsDeArquivo(string caminhoDoArquivo)
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