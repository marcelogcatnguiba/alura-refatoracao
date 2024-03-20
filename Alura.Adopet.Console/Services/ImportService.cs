using Alura.Adopet.Console.Repository;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("import", "Realiza a importação em lote de um arquivos de pets.\nDigite adopet import <arquivo>")]
    public class ImportService : IComando
    {
        private readonly IPetRepository _repository;
        public ImportService()
        {
            _repository = new PetRepository();
        }

        public async Task ExecutarComando(string[] args)
        {
            await ImportarArquivoPets(caminhoArquivoImportacao: args[1]);

        }

        private async Task ImportarArquivoPets(string caminhoArquivoImportacao)
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