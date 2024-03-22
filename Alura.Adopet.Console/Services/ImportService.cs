using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("import", "Realiza a importação em lote de um arquivos de pets.\nDigite adopet import <arquivo>")]
    public class ImportService : IComando
    {
        private readonly HttpClientPet _client;
        public ImportService()
        {
            _client = new HttpClientPet();
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
                    var resposta = await _client.CreatePetAsync(pet);
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