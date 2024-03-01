using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Repository
{
    public interface IPetRepository
    {
        public Task<HttpResponseMessage> CreatePetAsync(Pet pet);
        public Task<IEnumerable<Pet>?> ListPetsAsync();
    }
}