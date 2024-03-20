using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils.Extensions
{
    public static class StringExtension
    {
        public static string PrimeiraLetraMaiuscula(this string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}