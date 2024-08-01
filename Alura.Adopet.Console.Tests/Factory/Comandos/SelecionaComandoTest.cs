using Alura.Adopet.Console.Comandos.Import;
using Alura.Adopet.Console.Factory.Comandos;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Factory.Comandos
{
    public class SelecionaComandoTest
    {
        [Fact]
        public void DeveRetornarComando_ImportCliente()
        {
            string[] args = ["import-cliente", "lista.csv"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ImportClienteComando>();
        }
        
        [Fact]
        public void DeveRetornarComando_ImportPet()
        {
            string[] args = ["import-pet", "lista.csv"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ImportPetComando>();
        }
    }
}