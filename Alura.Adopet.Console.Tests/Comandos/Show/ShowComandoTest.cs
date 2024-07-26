using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;
using Moq;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers;

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
            Mock<LeitorCSVPet> leitor = new(Configuration.CaminhoArquivoImportacao);
            leitor.Setup(x => x.RealizarLeitura()).Returns(_pets);

            ShowComando show = new(leitor.Object);
            var success = await show.ExecutarComando();
            var result = (SuccessShow)success.Successes.First();
            
            result.Pets.Should().HaveCount(3);
        }
    }
}