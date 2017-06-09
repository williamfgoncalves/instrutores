using NGames.Domain.ValueObjects;
using System;

namespace NGames.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF
        protected Cliente()
        {
        }

        public Cliente(string nome, string cpf, DateTime dtNascimento, Genero genero, string logradouro, string cidade, string estado, string cep)
        {
            Nome = nome;
            Cpf = cpf;
            DtNascimento = dtNascimento;
            Genero = genero;
            Endereco = new Endereco(logradouro, cidade, estado, cep);

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome inválido.");

            if (string.IsNullOrWhiteSpace(Cpf))
                AddMessage("Cpf inválido.");

            if (DtNascimento==null)
                AddMessage("DtNascimento inválido.");

            if (string.IsNullOrWhiteSpace(Endereco.Cep))
                AddMessage("Cep inválido.");

            if (string.IsNullOrWhiteSpace(Endereco.Cidade))
                AddMessage("Cidade inválido.");

            if (string.IsNullOrWhiteSpace(Endereco.Estado))
                AddMessage("Estado inválido.");

            if (string.IsNullOrWhiteSpace(Endereco.Logradouro))
                AddMessage("Logradouro inválido.");
        }
    }
}
