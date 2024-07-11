using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.SuccessResult;
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
            try
            {
                var listaDePet = _leitorArquivo.RealizarLeitura();

                foreach (var pet in listaDePet)
                {
                    var resposta = await _client.CreatePetAsync(pet);
                }

                return Result.Ok().WithSuccess(new SuccessImport(listaDePet));
            }
            catch(NullReferenceException ex)
            {
                return Result.Fail(new Error("A lista de pets é nula").CausedBy(ex));
            }
            catch(Exception ex)
            {
                return Result.Fail(new Error("Importacao falhou !!").CausedBy(ex));
            }
            
        }
    }
}