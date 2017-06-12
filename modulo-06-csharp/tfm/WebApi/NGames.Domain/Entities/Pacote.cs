using System.Collections.Generic;

namespace NGames.Domain.Entities
{
    public class Pacote : EntityBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal Valor { get; private set; }

        // EF
        protected Pacote()
        {
        }

        public Pacote(string nome, decimal desconto, decimal valor)
        {
            Nome = nome;
            Desconto = desconto;
            Valor = valor;

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome inválido.");

            if (Desconto < 0)
                AddMessage("Diaria inválido.");

            if (Valor < 0)
                AddMessage("Valor inválido.");

        }
    }
}
