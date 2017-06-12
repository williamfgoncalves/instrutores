using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalhando
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    const string arquivo = @"C:\Users\fabriciosilva\Desktop\arquivo.txt";

        //    using (var reader = new StreamReader(arquivo))
        //    {
        //        var linhas = reader.ReadToEnd();
        //    }

        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            const string arquivo = @"C:\Users\fabriciosilva\Desktop\arquivo.txt";

            var linhas = File.ReadAllText(arquivo);

            File.AppendAllText(arquivo, "Hello world");

            Console.ReadKey();
        }
    }
}
