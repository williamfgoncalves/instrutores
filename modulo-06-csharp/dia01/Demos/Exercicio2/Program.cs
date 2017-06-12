using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] entradas = new int[] { };
            bool continua = true;

            Console.WriteLine("#---------DIGITE SOMENTE NÚMEROS (\"exit\" pra sair)---------#");

            while (continua)
            {
                var linhaLida = Console.ReadLine();
                if (linhaLida == "exit")
                {
                    break;
                }

                entradas = AdicionarNoVetor(entradas, int.Parse(linhaLida));

            }

            BoobleSort(entradas);

            foreach (var entrada in entradas)
            {
                Console.WriteLine(entrada);
            }

            Console.WriteLine("#---------FIM---------#");
            Console.ReadKey();
        }

        static int[] AdicionarNoVetor(int[] vetorEntrada, int elementoParaAdicionar)
        {
            var entradasAux = new int[vetorEntrada.Length + 1];
            vetorEntrada.CopyTo(entradasAux, 0);
            entradasAux[entradasAux.Length - 1] = elementoParaAdicionar;

            /*
            var nrEntradas = vetorEntrada.Length;

            var entradasAux = new int[nrEntradas + 1];
            
            for (int i = 0; i < nrEntradas; i++)
            {
                entradasAux[i] = vetorEntrada[i];
            }

            entradasAux[nrEntradas] = elementoParaAdicionar;
            */
            return entradasAux;
        }

        static void BoobleSort(int[] entradas)
        {
            int t;

            for (int p = 0; p <= entradas.Length - 2; p++)
            {
                for (int i = 0; i <= entradas.Length - 2; i++)
                {
                    if (entradas[i] > entradas[i + 1])
                    {
                        t = entradas[i + 1];
                        entradas[i + 1] = entradas[i];
                        entradas[i] = t;
                    }
                }
            }
        }
    }
}