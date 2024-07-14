using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.SuccessResult;
using FluentAssertions;
using Moq;

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

            Mock<PetService> clientMock = new(new HttpClientFactory().CreateClient());
            clientMock.Setup(x => x.ListPetsAsync()).ReturnsAsync(listaPets);

            ListComando service = new(clientMock.Object);
            
            var success = await service.ExecutarComando();
            var result = (SuccessList)success.Successes.First();

            result.Pets
                .Should()
                .HaveCount(3);
        }
    }
}