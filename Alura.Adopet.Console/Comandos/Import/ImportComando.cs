using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Services.Interfaces;
using FluentResults;

namespace Alura.Adopet.Console.Comandos.Import
{
    public class ImportComando<T>(
        ILeitor<T> leitorArquivo, IApiService<T> httpClientPet) : IComando, IComandoEventos
    {
        private readonly IApiService<T> _client = httpClientPet;
        private readonly ILeitor<T> _leitorArquivo = leitorArquivo;
        public event Action<Result>? DepoisDaExecucao;

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

                var result = Result.Ok().WithSuccess(new SuccessImport<T>(lista, "Importação realizada com sucesso !!"));
                DepoisDaExecucao?.Invoke(result);

                return result;
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