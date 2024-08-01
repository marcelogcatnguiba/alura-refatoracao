using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Entities;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Show
{
    [ClassDocuments("show", "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowComando(ILeitor<Pet> leitorArquivo) : IComando
    {
        private readonly ILeitor<Pet> _leitorDeArquivo = leitorArquivo;

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