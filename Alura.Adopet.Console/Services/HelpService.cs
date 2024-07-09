using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("help", "Exibe informações de ajuda dos comandos.\nDigite adopet help <comando> ou simplemente adopet help")]
    public class HelpService : IComando
    {
        public async Task<Result> ExecutarComando(string[] args)
        {
            if (args.Length == 1) 
                return await AjudaComandos();

            return await AjudaComandoEspecifico(args[1]);
        }
        private Task<Result> AjudaComandos()
        {
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessHelp()));
        }
        
        private Task<Result> AjudaComandoEspecifico(string comando)
        {
            var comandoInformacao = ListaDeDocumentacao.GetDocumentacao(comando);
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessHelp(comandoInformacao)));
        }
    }
}
