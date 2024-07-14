using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Result;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.SuccessResult;
using Moq;
using Alura.Adopet.Console.Readers.Interfaces;
using Alura.Adopet.Console.ConfigureHttp.Interfaces;

namespace Alura.Adopet.Console.Tests.Comandos.Import
{
    public class ImportComandoTest
    {
        private readonly Mock<ILeitor> _leitorArquivo = new();
        private readonly Mock<IAPIService> _clientPet = new();

        [Fact]
        public async Task DeveImportarPet_QuandoEstiverNoArquivo()
        {
            ResultReader resultReader = new()
            {
                Pets = 
                [
                    new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro)
                ]
            };
            
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(resultReader);
            _clientPet.Setup(x => x.CreatePetAsync(It.IsAny<Pet>())).ReturnsAsync(new HttpResponseMessage());

            ImportComando importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeveSerImportadoPet()
        {
            ResultReader resultReader = new()
            {
                Pets = 
                [
                    new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro)
                ]
            };
            
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(resultReader);
            _clientPet.Setup(x => x.CreatePetAsync(It.IsAny<Pet>())).ReturnsAsync(new HttpResponseMessage());

            ImportComando importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();
            var pet = (SuccessImport)result.Successes.First();

            Assert.Equal("Lima", pet.Pets.First().Nome);
        }
    }
}