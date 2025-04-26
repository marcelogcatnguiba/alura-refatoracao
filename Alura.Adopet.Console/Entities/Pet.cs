using Alura.Adopet.Console.Enums;

namespace Alura.Adopet.Console.Entities
{
    public class Pet(Guid id, string? nome, TipoPet tipo)
    {
        public Guid Id { get; set; } = id;
        public string? Nome { get; set; } = nome;
        public TipoPet Tipo { get; set; } = tipo;
        
        public override string ToString()
        {
            return $"{Id} - {Nome} - {Tipo}";
        }
    }
}
