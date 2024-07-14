using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComandoFactory : ComandoFactory
    {
        private readonly ILeitor _leitorArquivo;
        private readonly HttpClientPet _clientPet;
        private readonly string? _comando;

        public SelecionaComandoFactory(ILeitor leitorArquivo, HttpClientPet clientPet, string? comando = null)
        {
            _leitorArquivo = leitorArquivo;
            _clientPet = clientPet;
            _comando = comando;
        }
        
        public override IComando CriarComando(string comando)
        {
            var comandoEnum = ComandoToEnum(comando);

            return comandoEnum switch
            {
                TipoComando.Help => new HelpService(_comando),

                TipoComando.Import => new ImportService(_leitorArquivo, _clientPet),

                TipoComando.List => new ListService(_clientPet),

                TipoComando.Show => new ShowService(_leitorArquivo),
                
                _ => throw new Exception($"Falha fabrica de comandos"),
            };
        }

        private static TipoComando ComandoToEnum(string comando)
        {
            try
            {
                return (TipoComando)Enum.Parse(typeof(TipoComando), comando.PrimeiraLetraMaiuscula());
            }
            catch (Exception)
            {
                throw new Exception($"Comando {comando} invalido");
            }
        }
    }
}