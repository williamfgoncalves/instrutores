using Demo1.Entidades;
using System;

namespace Aula1.Demo1
{
    class Program
    {
        const double PI = 2.14;
        readonly string _diretorioPadrao = @"c:\windows\temp";

        public class Teste
        {
            public int Valor1 { get; set; }
        }

        static void Main(string[] args)
        {
            int vl1 = 0;
            Int32 vl2 = 0;
            Teste vlr3 = new Teste() { Valor1 = 1 };

            Teste1(ref vl1, vl2);

            Teste2(ref vlr3);

            Console.WriteLine("Hello world!");

            var pessoa = new Gerente("999.999.999.99");
            pessoa.Nome = "givoani";

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                case "2":
                    Console.WriteLine($"Digitou {opcao}");
                    Console.WriteLine($"Digitou 1 ou 2");
                    break;
                case "3":
                    Console.WriteLine("É 3");
                    break;
                default:
                    Console.WriteLine("Passou aqui");
                    break;

            }

            Console.ReadKey();
        }

        static void Teste1(ref int valor1, Int32 valor2)
        {
            valor1++;
            valor2++;
        }

        static void Teste2(ref Teste teste)
        {
            teste = new Teste();
        }
    }
}
