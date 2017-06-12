using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] entradas = new int[] { };
            // var entradas = new List<MinhaEntrada>();
            var entradas = new List<int>();
            bool continua = true;

            Console.WriteLine("#---------DIGITE SOMENTE NÚMEROS (\"exit\" pra sair)---------#");

            while (continua)
            {
                var linhaLida = Console.ReadLine();
                if (linhaLida == "exit")
                {
                    break;
                }

                entradas.Add(int.Parse(linhaLida));

            }

            var arrEntradas = entradas.ToArray();
            BoobleSort(arrEntradas);

            foreach (var entrada in arrEntradas)
            {
                Console.WriteLine(entrada);
            }

            Console.WriteLine("#---------FIM---------#");
            Console.ReadKey();
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
