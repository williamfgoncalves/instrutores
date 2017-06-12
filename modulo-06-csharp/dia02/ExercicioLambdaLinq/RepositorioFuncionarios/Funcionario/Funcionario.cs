using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TurnoTrabalho TurnoTrabalho { get; set; }
        public Cargo Cargo { get; set; }

        public Funcionario(int id, string nome, DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public int Idade
        {
            get
            {
                //Calula a idade subtraindo o ano atual pela data de nascimento
                int anos = DateTime.Now.Year - DataNascimento.Year;

                //Porém caso ele ainda não tenha feito aniversário nesse ano, o ano não conta
                bool mesDeAniversarioEhMenorQueOMesAtual = DateTime.Now.Month < DataNascimento.Month;
                bool mesDeAniversarioEhIgualMasDiaEhMenor = DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day;

                if (mesDeAniversarioEhMenorQueOMesAtual || mesDeAniversarioEhIgualMasDiaEhMenor)
                    anos--;

                return anos;
            }
        }
    }
}
