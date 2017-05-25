using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Entidades
{
    public class Gerente : Colaborador
    {
        public Gerente(string cpf)
        {
            Cpf = cpf;
        }
        public string Cpf { get; private set; }
    }
}
