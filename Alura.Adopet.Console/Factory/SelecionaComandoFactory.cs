using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Interfaces;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComandoFactory : ComandoFactory
    {
        private readonly LeitorCSV _leitorArquivo;
        private readonly HttpClientPet _clientPet;
        private readonly string? _comando;

        public SelecionaComandoFactory(LeitorCSV leitorArquivo, HttpClientPet clientPet, string? comando = null)
        {
            _leitorArquivo = leitorArquivo;
            _clientPet = clientPet;
            _comando = comando;
        }
        
        public override IComando CriarComando(TipoComando comando)
        {
            return comando switch
            {
                TipoComando.Help => new HelpService(_comando),

                TipoComando.Import => new ImportService(_leitorArquivo, _clientPet),

                TipoComando.List => new ListService(_clientPet),

                TipoComando.Show => new ShowService(_leitorArquivo),
                
                _ => throw new Exception("Comando Invalido"),
            };
        }
    }
}