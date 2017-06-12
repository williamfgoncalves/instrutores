using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoFrases
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorioFrases = new RepositorioFrases();

            Frase novaFrase = SolicitarNovaFrase();

            repositorioFrases.AdicionarFrase(novaFrase);
            
            PesquisarFrasesPorTermo(repositorioFrases);

            Console.ReadKey();
        }

        private static void PesquisarFrasesPorTermo(RepositorioFrases repositorioFrases)
        {
            Console.WriteLine("Procure o Termo");
            var termo = Console.ReadLine();
            var frasesRetornadas = repositorioFrases.BuscarFrase(termo);

            ImprimirFrases(frasesRetornadas);
        }

        private static void ImprimirFrases(List<Frase> frasesRetornadas)
        {
            foreach (var fraseRetornada in frasesRetornadas)
            {
                Console.WriteLine(fraseRetornada.ToString());
            }
        }

        private static Frase SolicitarNovaFrase()
        {
            Console.WriteLine("Digite uma nova frase:");
            var texto = Console.ReadLine();
            Console.WriteLine("Digite o autor:");
            var autor = Console.ReadLine();

            return new Frase(texto, autor);
        }
    }
}
