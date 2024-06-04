using System.Net;
using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Utils;
using Moq;

namespace Alura.Adopet.Console.Tests
{
    public class ImportCommandTestes
    {
        [Fact]
        public async void QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            // Given
            List<Pet> listaPets = [new Pet(Guid.NewGuid(), "Lima", TipoPet.Cachorro)];
            
            var leitorArquivo = new Mock<LeitorArquivo>();
            var httpClientPet = new Mock<HttpClientPet>(new PetClientFactory().CreateClient());

            leitorArquivo.Setup(x => 
                x.LeitorArquivoDePets(It.IsAny<string>())).Returns(listaPets);

            httpClientPet.Setup(x => 
                x.CreatePetAsync(It.IsAny<Pet>())).ReturnsAsync(new HttpResponseMessage());

            var importacao = new ImportService(leitorArquivo.Object, httpClientPet.Object);
            string[] args = ["import", "lista.csv"];

            // When
            var result = await importacao.ExecutarComando(args);

            // Then
            Assert.True(result.IsSuccess);
        }
    }
}