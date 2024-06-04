using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("import", "Realiza a importação em lote de um arquivos de pets.\nDigite adopet import <arquivo>")]
    public class ImportService : IComando
    {
        private readonly HttpClientPet _client;
        private readonly LeitorArquivo _leitorArquivo;
        public ImportService(LeitorArquivo leitorArquivo, HttpClientPet httpClientPet)
        {
            _leitorArquivo = leitorArquivo;
            _client = httpClientPet;
        }

        public async Task<Result> ExecutarComando(string[] args)
        {
            return await ImportarArquivoPets(caminhoArquivoImportacao: args[1]);
        }

        private async Task<Result> ImportarArquivoPets(string caminhoArquivoImportacao)
        {
            var listaDePet = _leitorArquivo.LeitorArquivoDePets(caminhoArquivoImportacao);

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

            return Result.Ok();
        }
    }
}