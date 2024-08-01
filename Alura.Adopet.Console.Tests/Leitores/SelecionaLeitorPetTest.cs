using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Leitores.LeitoresPets;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Leitores
{
    public class SelecionaLeitorPetTest
    {
        [Fact]
        public void DeveRetornarLeitor_CSVPet()
        {
            var result = SelecionaLeitorPet.CriarLeitor("lista.csv");
            result.Should().BeOfType<LeitorCSVPet>();
        }
        
        [Fact]
        public void DeveRetornarLeitor_JSONPet()
        {
            var result = SelecionaLeitorPet.CriarLeitor("lista.json");
            result.Should().BeOfType<LeitorJSONPet>();
        }
    }
}