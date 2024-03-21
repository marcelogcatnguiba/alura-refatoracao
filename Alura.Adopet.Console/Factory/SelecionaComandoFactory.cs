using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComandoFactory : ComandoFactory
    {
        public override IComando CriarComando(TipoComando comando)
        {
            switch (comando)
            {
                case TipoComando.Help:
                    return new HelpService();
                case TipoComando.Import:
                    return new ImportService();
                case TipoComando.List:
                    return new ListService();
                case TipoComando.Show:
                    return new ShowService();
                default:
                    throw new Exception("Comando Invalido");
            }
        }
    }
}