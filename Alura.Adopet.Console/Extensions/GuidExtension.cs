namespace Alura.Adopet.Console.Extensions
{
    public static class GuidExtension
    {
        public static bool IsNotGuid(string str)
        {
            return !Guid.TryParse(str, out Guid x);
        }
    }
}