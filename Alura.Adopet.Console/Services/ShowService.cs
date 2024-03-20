using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("show", "Comando que exibe no terminal o conteúdo do arquivo importado.\nDigite adopet show <arquivo>.")]
    public class ShowService : IComando
    {
        public async Task ExecutarComando(string[] args)
        {
            await ListarPetsDeArquivo(caminhoDoArquivo: args[1]);
        }

        public Task ListarPetsDeArquivo(string caminhoDoArquivo)
        {
            var listaDePet = LeitorArquivo.LeitorArquivoDePets(caminhoDoArquivo);

            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            foreach (var p in listaDePet)
                System.Console.WriteLine(p);

            return Task.CompletedTask;
        }
    }
}