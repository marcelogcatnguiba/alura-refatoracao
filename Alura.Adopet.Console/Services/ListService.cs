using Alura.Adopet.Console.Repository;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListService : IComando
    {
        private readonly IPetRepository _repository;
        public ListService()
        {
            _repository = new PetRepository();
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