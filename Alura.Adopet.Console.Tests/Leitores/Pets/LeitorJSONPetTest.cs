using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Enums;
using Alura.Adopet.Console.Leitores.LeitoresPets;
using FluentAssertions;
using Newtonsoft.Json;

namespace Alura.Adopet.Console.Tests.Leitores.Pets
{
    public class LeitorJSONPetTest : IDisposable
    {
        private readonly string _caminho;
        
        public LeitorJSONPetTest()
        {
            List<Pet> pets = 
            [
                new(Guid.NewGuid(), "Lima", TipoPet.Cachorro),
                new(Guid.NewGuid(), "Caito", TipoPet.Cachorro),
                new(Guid.NewGuid(), "Jossi", TipoPet.Gato),
                new(Guid.NewGuid(), "Breno", TipoPet.Gato),
            ];
            
            var json = JsonConvert.SerializeObject(pets);
            
            File.WriteAllText("pets.json", json);
            _caminho = Path.GetFullPath("pets.json");
        }

        [Fact]
        public void DeveRetornarListaPets_QuandoRealizarLeitura()
        {
            LeitorJSONPet leitorJSON = new(_caminho);

            var result = leitorJSON.RealizarLeitura();

            result.Should().HaveCount(4);
        }

        public void Dispose()
        {
            File.Delete(_caminho);
            GC.SuppressFinalize(this);
        }
    }
}