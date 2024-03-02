using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.Adopet.Console.Repository;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Services
{
    [ClassDocuments("list", "Comando que exibe a lista de pets cadastrados no sistema\nDigite adopet list")]
    public class ListService
    {
        private readonly IPetRepository _repository;
        public ListService()
        {
            _repository = new PetRepository();
        }
        public async Task ListarPetsCadastrados()
        {
            var listPets = await _repository.ListPetsAsync();
            foreach (var p in listPets!)
                System.Console.WriteLine(p);
        }
    }
}