namespace Alura.Adopet.Console.Validation
{
    public static class EnumValidation
    {
        public static bool IsNotEnum(string petString)
        {
            return !Enum.TryParse(petString, out TipoPet pet);
        }
    }
}