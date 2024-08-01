using Alura.Adopet.Console.Factory.Leitores;
using Alura.Adopet.Console.Leitores.LeitoresPets;
using FluentAssertions;

namespace Alura.Adopet.Console.Tests.Factory.Leitores
{
    public class SelecionaLeitorPetTest
    {
        [Fact]
        public void DeveRetornarLeitor_PetCSV()
        {
            var result = SelecionaLeitorPet.CriarLeitor("lista.csv");

            result.Should().BeOfType<LeitorCSVPet>();
        }
        
        [Fact]
        public void DeveRetornarLeitor_PetJSON()
        {
            var result = SelecionaLeitorPet.CriarLeitor("lista.json");

            result.Should().BeOfType<LeitorJSONPet>();
        }
    }
}