using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3.Entidades
{
    public class Colaborador
    {
        public Colaborador(string nome, double salaraioBase, Cargo cargo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            SalarioBase = salaraioBase;
            Cargo = cargo;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public double SalarioBase { get; private set; }
        public Cargo Cargo { get; private set; }
        public Endereco Edenreco { get; private set; }
    }
}
