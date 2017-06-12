namespace NGames.Domain.Entities
{
    public class Opcional : EntityBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Diaria { get; private set; }
        // EF
        protected Opcional() { }

        public Opcional(string nome, int quantidade, decimal diaria)
        {
            Nome = nome;
            Quantidade = quantidade;
            Diaria = diaria;

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome inválido.");

            if (Quantidade < 0)
                AddMessage("Quantidade inválido.");

            if (Diaria < 0)
                AddMessage("Diaria inválido.");
        }

        public void BaixarEstoque(int quantidade)
        {
            Quantidade -= quantidade;
        }

        public void AdicionarEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}