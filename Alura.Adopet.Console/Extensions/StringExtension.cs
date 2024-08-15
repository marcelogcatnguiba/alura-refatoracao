using Alura.Adopet.Console.Entities;
using Alura.Adopet.Console.Exeptions;

namespace Alura.Adopet.Console.Extensions
{
    public static class StringExtension
    {
        public static string PrimeiraLetraMaiuscula(this string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
        
        public static Pet RetornaPetString(this string petString)
        {
            string[] petSeparado = petString.Split(";");

            PetStringException.Quando(string.IsNullOrEmpty(petString),
                "String vazia ou nula");

            PetStringException.Quando(petSeparado.Length != 3,
                "String invalida para converção");

            PetStringException.Quando(GuidExtension.IsNotGuid(petSeparado[0]),
                "Guid invalido");

            PetStringException.Quando(EnumExtension.IsNotEnum(petSeparado[2]),
                "Tipo de pet invalido");

            var petId = Guid.Parse(petSeparado[0]);
            var petNome = petSeparado[1];
            var petTipo = (TipoPet)Enum.Parse(typeof(TipoPet), petSeparado[2]);

            return new Pet(petId, petNome, petTipo);
        }
    }
}