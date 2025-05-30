using Alura.Adopet.Console.Factory.Services;
using Alura.Adopet.Console.Factory.Services.Main;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Clientes;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Factory.Services
{
    public class SelecionaServicoClienteTest
    {
        [Fact]
        public void DeveRetornarServico_Cliente()
        {
            var result = SelecionaServicoCliente.CriarServico();
            result.Should().BeOfType<ClienteService>();
        }
    }
}