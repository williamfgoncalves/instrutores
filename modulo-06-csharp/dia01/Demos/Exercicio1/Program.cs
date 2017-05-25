using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    class Program
    {
        // função estática não está associada a uma instância de uma classe
        static void Main(string[] args)
        {
            int[] entradas = new int[] { };
            // int[] entradas = new int[3] {10,11,22 };
            // var entradas = new int[] { };
            // var entradas = new int[5] { 0, 1, 2, 3, 4 };
            bool continua = true;

            Console.WriteLine("#---------DIGITE SOMENTE NÚMEROS (\"exit\" pra sair)---------#");

            while (continua)
            {
                var linhaLida = Console.ReadLine();
                if (linhaLida == "exit")
                {
                    break;
                }

                var nrEntradas = entradas.Length;

                var entradasAux = new int[nrEntradas + 1];

                for (int i = 0; i < nrEntradas; i++)
                {
                    entradasAux[i] = entradas[i];
                }

                entradasAux[nrEntradas] = int.Parse(linhaLida);

                entradas = entradasAux;
            }

            foreach (var entrada in entradas)
            {
                Console.WriteLine(entrada);
            }

            Console.WriteLine("#---------FIM---------#");
            Console.ReadKey();
        }

    }
}