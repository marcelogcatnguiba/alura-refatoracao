using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Readers.Result;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.SuccessResult;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Import
{
    public class ImportComandoTest
    {
        private readonly Mock<LeitorCSV> _leitorArquivo;
        private readonly Mock<HttpClientPet> _clientPet;

        public ImportComandoTest()
        {
            _leitorArquivo = new Mock<LeitorCSV>(Configuration.CaminhoArquivoImportacao);
            _clientPet = new Mock<HttpClientPet>(new PetClientFactory().CreateClient());
        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
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