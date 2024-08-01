using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Documentation;
using FluentResults;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("show", "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowComando : IComando
    {
        private readonly ILeitor<Pet> _leitorDeArquivo;

        public ShowComando(ILeitor<Pet> leitorArquivo)
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