using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Comandos;
using FluentAssertions;
using Moq;
using Alura.Adopet.Console.Entities;

namespace Alura.Adopet.Console.Tests.Comandos.Factory
{
    public class SelecionaComandoTest
    {
        private readonly Mock<ILeitor<Pet>> _leitor = new();

        [Fact]
        public void DeveRetornarComando_Import()
        {
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(_leitor.Object, client.Object);
            var result = factory.CriarComando("import");

            result.Should().BeOfType<ImportComando>();
        }

        [Fact]
        public void DeveRetornarComando_Help()
        {
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(_leitor.Object, client.Object);
            var result = factory.CriarComando("help");

            result.Should().BeOfType<HelpComando>();
        }

        [Fact]
        public void DeveRetornarComando_Show()
        {
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(_leitor.Object, client.Object);
            var result = factory.CriarComando("show");

            result.Should().BeOfType<ShowComando>();
        }

        [Fact]
        public void DeveRetornarComando_List()
        {
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(_leitor.Object, client.Object);
            var result = factory.CriarComando("list");

            result.Should().BeOfType<ListComando>();
        }

        [Fact]
        public void DeveRetornarException_QuandoComandoInvalido()
        {
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(_leitor.Object, client.Object);
            Action action = () => factory.CriarComando("invalido");

            action.Should().Throw<Exception>().WithMessage("Comando invalido invalido");
        }
    }
}