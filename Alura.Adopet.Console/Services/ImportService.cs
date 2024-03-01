using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Repository;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    public class ImportService
    {
        private readonly IPetRepository _repository;
        public ImportService()
        {
            _repository = new PetRepository();
        }

        public async Task ImportarArquivoPets(string caminhoArquivoImportacao)
        {
            var listaDePet = LeitorArquivo.LeitorArquivoDePets(caminhoArquivoImportacao);

            foreach (var pet in listaDePet)
            {
                try
                {
                    var resposta = await _repository.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}