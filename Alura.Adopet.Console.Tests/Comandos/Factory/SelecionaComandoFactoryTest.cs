using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Factory;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.Services;
using FluentAssertions;
using FluentAssertions.Specialized;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Factory
{
    public class SelecionaComandoFactoryTest
    {
        [Fact]
        public void DeveRetornarComando_Import()
        {
            Mock<ILeitor> leitor = new();
            Mock<HttpClientPet> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComandoFactory(leitor.Object, client.Object);
            var result = factory.CriarComando("import");

            result.Should().BeOfType<ImportService>();
        }

        [Fact]
        public void DeveRetornarComando_Help()
        {
            Mock<ILeitor> leitor = new();
            Mock<HttpClientPet> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComandoFactory(leitor.Object, client.Object);
            var result = factory.CriarComando("help");

            result.Should().BeOfType<HelpService>();
        }

        [Fact]
        public void DeveRetornarComando_Show()
        {
            Mock<ILeitor> leitor = new();
            Mock<HttpClientPet> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComandoFactory(leitor.Object, client.Object);
            var result = factory.CriarComando("show");

            result.Should().BeOfType<ShowService>();
        }

        [Fact]
        public void DeveRetornarComando_List()
        {
            Mock<ILeitor> leitor = new();
            Mock<HttpClientPet> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComandoFactory(leitor.Object, client.Object);
            var result = factory.CriarComando("list");

            result.Should().BeOfType<ListService>();
        }

        [Fact]
        public void DeveRetornarException_QuandoComandoInvalido()
        {
            Mock<ILeitor> leitor = new();
            Mock<HttpClientPet> client = new(It.IsAny<HttpClient>());

            var factory = new SelecionaComandoFactory(leitor.Object, client.Object);
            Action action = () => factory.CriarComando("invalido");

            action.Should().Throw<Exception>().WithMessage("Comando invalido invalido");
        }
    }
}