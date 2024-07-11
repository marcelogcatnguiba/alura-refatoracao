using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Readers;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.SuccessResult;
using Moq;

namespace Alura.Adopet.Console.Tests.Comandos.Import
{
    public class ImportSericeTest
    {
        private readonly Mock<LeitorCSV> _leitorArquivo;
        private readonly Mock<HttpClientPet> _clientPet;

        public ImportSericeTest()
        {
            _leitorArquivo = new Mock<LeitorCSV>(Configuration.CaminhoArquivoImportacao);
            _clientPet = new Mock<HttpClientPet>(new PetClientFactory().CreateClient());
        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            List<Pet> listaPets = [ new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro) ];
            
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(listaPets);
            _clientPet.Setup(x => x.CreatePetAsync(It.IsAny<Pet>())).ReturnsAsync(new HttpResponseMessage());

            ImportService importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task DeveSerImportadoPet()
        {
            List<Pet> listaPets = [ new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro) ];
            
            _leitorArquivo.Setup(x => x.RealizarLeitura()).Returns(listaPets);
            _clientPet.Setup(x => x.CreatePetAsync(It.IsAny<Pet>())).ReturnsAsync(new HttpResponseMessage());

            ImportService importacao = new (_leitorArquivo.Object, _clientPet.Object);
            
            var result = await importacao.ExecutarComando();
            var pet = (SuccessImport)result.Successes.First();

            Assert.Equal("Lima", pet.Pets.First().Nome);
        }
    }
}