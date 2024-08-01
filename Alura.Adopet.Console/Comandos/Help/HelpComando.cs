using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Help
{
    [ClassDocuments("help", "Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpComando(string[] args) : IComando
    {
        public async Task<Result> ExecutarComando()
        {
            if(args.Length == 2)
            {
                return await AjudaComandoEspecifico(comando: args[1]);
            }
            
            return await AjudaComandos();
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
