using Alura.Adopet.Console.ConfigureHttp;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListService : IComando
    {
        private readonly HttpClientPet _repository;
        public ListService()
        {
            _repository = new HttpClientPet();
        }

        public async Task ExecutarComando(string[] args)
        {
            await ListarPetsCadastrados();
        }

        private async Task ListarPetsCadastrados()
        {
            var listPets = await _repository.ListPetsAsync();
            foreach (var p in listPets!)
                System.Console.WriteLine(p);
        }
    }
}