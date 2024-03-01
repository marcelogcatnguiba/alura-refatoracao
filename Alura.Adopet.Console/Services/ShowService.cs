using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    public class ShowService
    {
        public void ListarPetsDeArquivo(string caminhoDoArquivo)
        {
            var listaDePet = LeitorArquivo.LeitorArquivoDePets(caminhoDoArquivo);

            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            foreach (var p in listaDePet)
                System.Console.WriteLine(p);
        }
    }
}