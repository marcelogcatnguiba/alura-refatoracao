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
            var listaDePet = _leitorDeArquivo.LeitorArquivoDePets(caminhoDoArquivo);

            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            foreach (var p in listaDePet)
                System.Console.WriteLine(p);

            return Task.FromResult(Result.Ok());
        }
    }
}