using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils.Extensions
{
    public static class StringExtension
    {
        public static string PrimeiraLetraMaiuscula(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
        public static Pet RetornaPetString(this string str)
        {
            Guid guid;
            TipoPet tipoPet;

            if (string.IsNullOrEmpty(str))
                throw new Exception("String vazia ou nula");

            if (str.Split(";").Count() != 3)
                throw new Exception("String invalida para converção");

            if (Guid.TryParse(str.Split(";")[0], out guid) is false)
                throw new FormatException("Guid invalido");

            if (Enum.TryParse(str.Split(";")[2], out tipoPet) is false)
                throw new FormatException("Tipo de pet invalido");

            var nome = str.Split(";")[1];

            return new Pet(guid, nome, tipoPet);

        }
    }
}