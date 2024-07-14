using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using FluentResults;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;

namespace Alura.Adopet.Console.Comandos
{
    [ClassDocuments("import", "Realiza a importação em lote de um arquivos de pets.\nDigite adopet import <arquivo>")]
    public class ImportComando : IComando
    {
        private readonly IAPIService _client;
        private readonly ILeitor _leitorArquivo;
        
        public ImportComando(ILeitor leitorArquivo, IAPIService httpClientPet)
        {
            _leitorArquivo = leitorArquivo;
            _client = httpClientPet;
        }

        public async Task<Result> ExecutarComando()
        {
            return await ImportarArquivoPets();
        }

        private async Task<Result> ImportarArquivoPets()
        {
            try
            {
                var listaDePet = _leitorArquivo.RealizarLeitura();

                foreach (var pet in listaDePet.Pets)
                {
                    var resposta = await _client.CreatePetAsync(pet);
                }

                return Result.Ok().WithSuccess(new SuccessImport(listaDePet.Pets));
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