using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Alura.Adopet.Console.ConfigureHttp;

namespace Alura.Adopet.Console.Tests
{
    public class HttpClientPetTests
    {
        [Fact]
        public async Task DeveRetornarListaPets_NaoVazia()
        {
            var cliente = new HttpClientPet();

            var lista = await cliente.ListPetsAsync();

            Assert.NotNull(lista);
        }

        [Fact]
        public async Task DadoAPIFora_DeveRetornarExcecao()
        {
            var cliente = new HttpClientPet(uri: "http://localhost:1111");

            await Assert.ThrowsAnyAsync<Exception>(() => cliente.ListPetsAsync());
        }

    }
}