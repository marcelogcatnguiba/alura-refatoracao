using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Validation
{
    public static class EnumValidation
    {
        public static bool IsNotEnum(string petString)
        {
            TipoPet pet;
            return !Enum.TryParse(petString, out pet);
        }
    }
}