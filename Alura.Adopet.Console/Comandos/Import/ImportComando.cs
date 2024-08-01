using Alura.Adopet.Console.Documentation;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Services.Interfaces;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Import
{
    [ClassDocuments("import", "Realiza a importação em lote de um arquivos.\nDigite adopet import-[clientes / pets] <arquivo>")]
    public class ImportComando<T> : IComando
    {
        private readonly IAPIService<T> _client;
        private readonly ILeitor<T> _leitorArquivo;
        
        public ImportComando(ILeitor<T> leitorArquivo, IAPIService<T> httpClientPet)
        {
            _leitorArquivo = leitorArquivo;
            _client = httpClientPet;
        }

        public async Task<Result> ExecutarComando()
        {
            return await ImportarArquivo();
        }

        private async Task<Result> ImportarArquivo()
        {
            try
            {
                var lista = _leitorArquivo.RealizarLeitura();

                foreach (var obj in lista)
                {
                    await _client.CreateAsync(obj);
                }

                return Result.Ok().WithSuccess(new SuccessImport<T>(lista));
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