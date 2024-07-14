using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Comandos;
using FluentAssertions;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Factory
{
    public class SelecionaComandoTest
    {
        [Fact]
        public void DeveRetornarComando_Import()
        {
            Mock<ILeitor> leitor = new();
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(leitor.Object, client.Object);
            var result = factory.CriarComando("import");

            result.Should().BeOfType<ImportComando>();
        }

        [Fact]
        public void DeveRetornarComando_Help()
        {
            Mock<ILeitor> leitor = new();
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(leitor.Object, client.Object);
            var result = factory.CriarComando("help");

            result.Should().BeOfType<HelpComando>();
        }

        [Fact]
        public void DeveRetornarComando_Show()
        {
            Mock<ILeitor> leitor = new();
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(leitor.Object, client.Object);
            var result = factory.CriarComando("show");

            result.Should().BeOfType<ShowComando>();
        }

        [Fact]
        public void DeveRetornarComando_List()
        {
            Mock<ILeitor> leitor = new();
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(leitor.Object, client.Object);
            var result = factory.CriarComando("list");

            result.Should().BeOfType<ListComando>();
        }

        [Fact]
        public void DeveRetornarException_QuandoComandoInvalido()
        {
            Mock<ILeitor> leitor = new();
            Mock<PetService> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComando(leitor.Object, client.Object);
            Action action = () => factory.CriarComando("invalido");

            action.Should().Throw<Exception>().WithMessage("Comando invalido invalido");
        }
    }
}