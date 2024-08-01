using Alura.Adopet.Console.Comandos.Help;
using Alura.Adopet.Console.Comandos.Import;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Entities;
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

        [Theory]
        [InlineData("help")]
        [InlineData("help", "help")]
        [InlineData("help", "list")]
        [InlineData("help", "show")]
        [InlineData("help", "import-cliente")]
        [InlineData("help", "import-pet")]
        public void DeveRetornarComando_Help(string comando, string comandoEspecifico = "")
        {
            string[] args = [comando, comandoEspecifico];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<HelpComando>();
        }

        [Fact]
        public void DeveRetornarComando_Show()
        {
            string[] args = ["show-pet", "lista.csv"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ShowPetComando>();
        }

        // [Fact]
        // public void DeveRetornarComando_List()
        // {
        //     string[] args = ["list"];
            
        //     var result = SelecionaComando.CriarComando(args);

        //     result.Should().BeOfType<ShowComando>();
        // }
    }
}