using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComandoFactory : ComandoFactory
    {
        private readonly LeitorArquivo _leitorArquivo;
        private readonly HttpClientPet _clientPet;
        public SelecionaComandoFactory(LeitorArquivo leitorArquivo, HttpClientPet clientPet)
        {
            _leitorArquivo = leitorArquivo;
            _clientPet = clientPet;
        }
        public override IComando CriarComando(TipoComando comando)
        {
            switch (comando)
            {
                case TipoComando.Help:
                    return new HelpService();

                case TipoComando.Import:
                    return new ImportService(_leitorArquivo, _clientPet);

                case TipoComando.List:
                    return new ListService(_clientPet);

                case TipoComando.Show:
                    return new ShowService(_leitorArquivo);

                default:
                    throw new Exception("Comando Invalido");
            }
        }
    }
}