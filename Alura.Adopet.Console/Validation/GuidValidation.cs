using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils.Extensions
{
    public static class GuidValidation
    {
        public static bool IsNotGuid(string str)
        {
            Guid x;
            return !Guid.TryParse(str, out x);
        }
    }
}