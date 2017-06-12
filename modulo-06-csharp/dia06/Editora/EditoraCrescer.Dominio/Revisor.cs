namespace EditoraCrescer.Dominio
{
    public class Revisor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        protected Revisor() { } //EF

        public Revisor(string nome)
        {
            Nome = nome;
        }
    }
}
