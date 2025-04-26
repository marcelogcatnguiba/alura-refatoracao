using Alura.Adopet.Console.Enums;

namespace Alura.Adopet.Console.Extensions
{
    public static class EnumExtension
    {
        public static bool IsNotEnum(string petString)
        {
            return !Enum.TryParse(petString, out TipoPet pet);
        }
    }
}