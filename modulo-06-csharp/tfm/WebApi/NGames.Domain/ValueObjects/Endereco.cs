namespace NGames.Domain.ValueObjects
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }

        protected Endereco() { }

        public Endereco(string logradouro, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }
    }
}
