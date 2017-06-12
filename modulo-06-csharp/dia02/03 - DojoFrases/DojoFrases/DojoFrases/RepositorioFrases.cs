using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoFrases
{
    public class RepositorioFrases
    {
        const string arquivo = @"C:\Users\fabriciosilva\Desktop\frases.csv";
        List<Frase> frases = new List<Frase>();

        public RepositorioFrases()
        {
            var linhas = File.ReadAllLines(arquivo);

            foreach (var linha in linhas)
            {
                frases.Add(new Frase(linha));
            }
        }

        public void AdicionarFrase(Frase frase)
        {
            File.AppendAllText(arquivo, frase.ToString());
            frases.Add(frase);
        }

        public List<Frase> BuscarFrase(string termo)
        {
            return frases
                    .Where(t => t.Texto.Contains(termo))
                    .ToList();
        }
    }
}
