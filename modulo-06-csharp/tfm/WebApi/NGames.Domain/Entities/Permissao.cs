namespace NGames.Domain.Entities
{
    public class Permissao : EntityBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        // EF
        protected Permissao() { }

        public Permissao(string nome)
        {
            Nome = nome;

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome da permmissão é inválido.");
        }
    }
}