using Alura.Adopet.Console.Comandos.Help;
using Alura.Adopet.Console.Comandos.Import;
using Alura.Adopet.Console.Comandos.List;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Comandos;
using Alura.Adopet.Console.Factory.Comandos.Main;
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
        [InlineData("list-cliente")]
        [InlineData("list-pet")]
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

        [Fact]
        public void DeveRetornarComando_ListCliente()
        {
            string[] args = ["list-cliente"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ListClienteComando>();
        }
        
        [Fact]
        public void DeveRetornarComando_ListPet()
        {
            string[] args = ["list-pet"];
            
            var result = SelecionaComando.CriarComando(args);

            result.Should().BeOfType<ListPetComando>();
        }
    }
}