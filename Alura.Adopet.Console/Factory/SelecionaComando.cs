using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities.Enums;
using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComando : ComandoFactory
    {
        private readonly ILeitor _leitorArquivo;
        private readonly IAPIService<Pet> _clientPet;
        private readonly string? _comando;

        public SelecionaComando(ILeitor leitorArquivo, IAPIService<Pet> clientPet, string? comando = null)
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
                TipoComando.Help => new HelpComando(_comando),

                TipoComando.Import => new ImportComando(_leitorArquivo, _clientPet),

                TipoComando.List => new ListComando(_clientPet),

                TipoComando.Show => new ShowComando(_leitorArquivo),
                
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