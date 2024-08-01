using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Comandos.Import;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Import
{
    public class ImportPetComandoTest
    {
        private readonly Mock<ILeitor<Pet>> _leitorArquivo = new();
        private readonly Mock<IAPIService<Pet>> _clientPet = new();
        private readonly List<Pet> _pets;

        public ImportPetComandoTest()
        {
            _pets = 
            [
                new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro)
            ];
        }

        [Fact]
        public async Task DeveImportarPet_QuandoEstiverNoArquivo()
        {
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(_pets);
            _clientPet.Setup(x => x.CreateAsync(It.IsAny<Pet>()));

            ImportPetComando importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeveSerImportadoPet()
        {
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(_pets);
            _clientPet.Setup(x => x.CreateAsync(It.IsAny<Pet>()));

            ImportPetComando importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();
            var pet = (SuccessImport<Pet>)result.Successes.First();

            Assert.Equal("Lima", pet.Entities.First().Nome);
        }
    }
}