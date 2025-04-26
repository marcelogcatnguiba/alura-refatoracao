using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Factory.Interfaces.Leitores;
using Alura.Adopet.Console.Leitores.Interfaces;
using Alura.Adopet.Console.Leitores.LeitoresPets;

namespace Alura.Adopet.Console.Factory.Leitores.Pets
{
    public class LeitorCSVPetFactory : ILeitorFactory<Pet>
    {
        public bool ConsegueCriarLeitor(Type? type)
        {
            return type?.IsAssignableTo(typeof(LeitorCSVPet)) ?? false;
        }

        public ILeitor<Pet> CriarLeitor(string caminhoArquivo)
        {
            return new LeitorCSVPet(caminhoArquivo);
        }
    }
}