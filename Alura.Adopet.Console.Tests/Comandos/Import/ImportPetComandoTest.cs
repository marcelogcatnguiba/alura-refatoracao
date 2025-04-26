using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.SuccessResult;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Services.Interfaces;
using Alura.Adopet.Console.Comandos.Import;
using Moq;
using Alura.Adopet.Console.Enums;

namespace Alura.Adopet.Console.Tests.Comandos.Import
{
    public class ImportPetComandoTest
    {
        private readonly Mock<ILeitor<Pet>> _leitor = new();
        private readonly Mock<IApiService<Pet>> _service = new();
        private readonly List<Pet> _entities;

        public ImportPetComandoTest()
        {
            _entities = 
            [
                new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro)
            ];
        }

        [Fact]
        public async Task DeveImportarPet_QuandoEstiverNoArquivo()
        {
            _leitor.Setup(x => x.RealizarLeitura()).Returns(_entities);
            _service.Setup(x => x.CreateAsync(It.IsAny<Pet>()));

            ImportPetComando importacao = new (_leitor.Object, _service.Object);
            
            var result = await importacao.ExecutarComando();

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeveSerImportadoPet()
        {
            _leitor.Setup(x => x.RealizarLeitura()).Returns(_entities);
            _service.Setup(x => x.CreateAsync(It.IsAny<Pet>()));

            ImportPetComando importacao = new (_leitor.Object, _service.Object);
            
            var result = await importacao.ExecutarComando();
            var pet = (SuccessImport<Pet>)result.Successes.First();

            Assert.Equal("Lima", pet.Entities.First().Nome);
        }
    }
}