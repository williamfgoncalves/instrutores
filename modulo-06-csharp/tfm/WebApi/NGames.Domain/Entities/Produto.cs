namespace NGames.Domain.Entities
{
    public class Produto : EntityBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Diaria { get; private set; }

        // EF
        protected Produto()
        {
        }

        public Produto(string nome, int quantidade, decimal diaria)
        {
            Nome = nome;
            Quantidade = quantidade;
            Diaria = diaria;

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome inválido.");

            if (quantidade < 0)
                AddMessage("Quantidade inválido.");

            if (diaria < 0)
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
