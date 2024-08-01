using Alura.Adopet.Console.Factory.Services;
using Alura.Adopet.Console.Services;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Factory.Services
{
    public class SelecionaServicoPetTest
    {
        [Fact]
        public void DeveRetornarServico_Pet()
        {
            var result = SelecionaServicoPet.CriarServico();
            result.Should().BeOfType<PetService>();
        }
    }
}