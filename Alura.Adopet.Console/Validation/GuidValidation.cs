namespace Alura.Adopet.Console.Utils.Extensions
{
    public static class GuidValidation
    {
        public static bool IsNotGuid(string str)
        {
            return !Guid.TryParse(str, out Guid x);
        }
    }
}