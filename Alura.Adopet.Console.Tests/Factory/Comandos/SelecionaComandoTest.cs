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
        [InlineData("")]
        [InlineData("help")]
        [InlineData("list")]
        [InlineData("show-cliente")]
        [InlineData("show-pet")]
        [InlineData("import-cliente")]
        [InlineData("import-pet")]
        public void DeveRetornarComando_Help(string comando = "")
        {
            string[] args = ["help", comando];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<HelpComando>();
        }

        [Fact]
        public void DeveRetornarComando_ShowPet()
        {
            string[] args = ["show-pet", "lista.csv"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ShowPetComando>();
        }
        
        [Fact]
        public void DeveRetornarComando_ShowCliente()
        {
            string[] args = ["show-cliente", "lista.csv"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ShowClienteComando>();
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