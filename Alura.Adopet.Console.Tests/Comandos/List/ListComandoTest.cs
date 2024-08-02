using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Comandos.List;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;
using Moq;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Tests.Comandos.List
{
    public class ListComandoTest
    {
        [Fact]
        public async Task DeveConterPetsNaLista()
        {
            List<Pet> listaPets = 
            [
                new(Guid.NewGuid(), "Luna", TipoPet.Gato),
                new(Guid.NewGuid(), "Mira", TipoPet.Cachorro),
                new(Guid.NewGuid(), "Kira", TipoPet.Gato)
            ];

            Mock<PetService> clientMock = new(new HttpClientFactory(Configurations.ApiSettings.Uri).CreateClient());
            clientMock.Setup(x => x.ListAsync()).ReturnsAsync(listaPets);

            ListPetComando service = new(clientMock.Object);
            
            var success = await service.ExecutarComando();
            var result = (SuccessList<Pet>)success.Successes.First();

            result.Entities
                .Should()
                .HaveCount(3);
        }
    }
}