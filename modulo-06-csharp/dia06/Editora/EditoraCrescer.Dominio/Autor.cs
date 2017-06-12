namespace EditoraCrescer.Dominio
{
    public class Autor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        protected Autor() { } //EF

        public Autor(string nome)
        {
            Nome = nome;
        }
    }
}
