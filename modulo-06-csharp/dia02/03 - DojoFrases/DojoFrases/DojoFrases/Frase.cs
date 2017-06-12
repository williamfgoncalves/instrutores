using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoFrases
{
    public class Frase
    {
        public string Texto { get; private set; }
        public string Autor { get; private set; }

        public Frase(string texto, string autor)
        {
            if (texto.Contains("Nunes"))
                throw new Exception("Não pode!");

            Texto = texto;
            Autor = autor;
        }

        public Frase(string linha)
        {
            var linhaSplitada = linha.Split(';');
            Texto = linhaSplitada[0];
            Autor = linhaSplitada[1];
        }

        public override string ToString()
        {
            return $"\n{Texto}; ({Autor});";
        }
    }
}
