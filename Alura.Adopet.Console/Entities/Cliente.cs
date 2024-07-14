namespace Alura.Adopet.Console.Entities
{
    public class Cliente(Guid id, string nome, string email)
    {
        public Guid Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string Email { get; set; } = email;
        public string? CPF { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Email}";
        }
    }
}