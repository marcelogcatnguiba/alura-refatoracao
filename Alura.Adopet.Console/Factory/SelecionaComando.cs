using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Comandos.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Factory
{
    public class SelecionaComando : ComandoFactory
    {
        private readonly ILeitor<Pet> _leitorArquivo;
        private readonly IAPIService<Pet> _clientPet;
        private readonly string? _comando;

        public SelecionaComando(ILeitor<Pet> leitorArquivo, IAPIService<Pet> clientPet, string? comando = null)
        {
            _leitorArquivo = leitorArquivo;
            _clientPet = clientPet;
            _comando = comando;
        }
        
        public override IComando CriarComando(string comando)
        {
            
            return comando switch
            {
                "help" => new HelpComando(_comando),

                "import" => new ImportComando<Pet>(_leitorArquivo, _clientPet),

                "list" => new ListComando(_clientPet),

                "show" => new ShowComando(_leitorArquivo),
                
                _ => throw new Exception($"Comando {comando} invalido"),
            };
        }
    }
}