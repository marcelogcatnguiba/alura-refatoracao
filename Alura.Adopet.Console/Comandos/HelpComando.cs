using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("help", "Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpComando(string? comando = null) : IComando
    {
        private readonly string? _comando = comando;

        public async Task<Result> ExecutarComando()
        {
            if (_comando is null) 
                return await AjudaComandos();

            return await AjudaComandoEspecifico(_comando);
        }
        
        private static Task<Result> AjudaComandos()
        {
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessHelp()));
        }
        
        private static Task<Result> AjudaComandoEspecifico(string comando)
        {
            var comandoInformacao = ListaDeDocumentacao.GetDocumentacao(comando);
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessHelp(comandoInformacao)));
        }
    }
}