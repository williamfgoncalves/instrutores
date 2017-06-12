using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Entidades
{
    public class Endereco
    {
        public Endereco(string logradouro, string cep)
        {
            Logradouro = logradouro;
            Cep = cep;
        }

        public string Logradouro { get; private set; }
        public string Cep { get; private set; }
    }
}
