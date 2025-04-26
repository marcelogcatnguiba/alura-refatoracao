using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;
using Moq;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Leitores.LeitoresPets;
using Alura.Adopet.Console.Comandos.Show;
using Alura.Adopet.Console.Enums;

namespace Alura.Adopet.Console.Tests.Comandos.Show
{
    public class ShowComandoTest
    {
        private readonly List<Pet> _pets;

        public ShowComandoTest()
        {
            _pets = 
            [
                new(Guid.NewGuid(), "Luna", TipoPet.Gato),
                new(Guid.NewGuid(), "Mira", TipoPet.Cachorro),
                new(Guid.NewGuid(), "Kira", TipoPet.Gato)
            ];
        }
        [Fact]
        public async Task DeveConterPetsNaLista()
        {
            Mock<LeitorCSVPet> leitor = new("lista.csv");
            leitor.Setup(x => x.RealizarLeitura()).Returns(_pets);

            ShowComando<Pet> show = new(leitor.Object);
            var success = await show.ExecutarComando();
            var result = (SuccessShow<Pet>)success.Successes.First();
            
            result.Entities.Should().HaveCount(3);
        }
    }
}