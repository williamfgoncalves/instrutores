using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NGames.Domain.Entities
{
    public class Usuario : EntityBase
    {
        static readonly char[] _caracteresNovaSenha = "abcdefghijklmnopqrstuvzwyz1234567890*-_".ToCharArray();
        static readonly int _numeroCaracteresNovaSenha = 10;

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<Permissao> Permissoes { get; private set; }

        // EF
        protected Usuario()
        {
        }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Id = Guid.NewGuid();

            if (!string.IsNullOrWhiteSpace(senha))
                Senha = CriptografarSenha(senha);

            Permissoes = new List<Permissao>();

            if (string.IsNullOrWhiteSpace(Nome))
                AddMessage("Nome é inválido.");

            if (string.IsNullOrWhiteSpace(Email))
                AddMessage("Email é inválido.");

            if (string.IsNullOrWhiteSpace(Senha))
                AddMessage("Senha é inválido.");

        }

        public string ResetarSenha()
        {
            var senha = string.Empty;
            for (int i = 0; i < _numeroCaracteresNovaSenha; i++)
            {
                senha += new Random().Next(0, _caracteresNovaSenha.Length);
            }

            Senha = CriptografarSenha(senha);

            return senha;
        }

        private string CriptografarSenha(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Default.GetBytes(Email + senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

        public bool ValidarSenha(string senha)
        {
            return CriptografarSenha(senha) == Senha;
        }

        public void AtribuirPermisao(Permissao permissao)
        {
            Permissoes.Add(permissao);
        }
    }
}
