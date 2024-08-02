namespace Alura.Adopet.Console.Settings
{
    public class EmailSettings
    {
        public const string Section = "EmailSettings";
        public string Servidor { get; set; } = string.Empty;
        public int Porta { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}