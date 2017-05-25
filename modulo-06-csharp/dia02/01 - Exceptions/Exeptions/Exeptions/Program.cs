using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeroDigitado = Console.ReadLine();
            try
            {
                var numeroConvertido = Convert.ToInt32(numeroDigitado);

                if (numeroConvertido == 13)
                    throw new NumeroDeAzarException();

                Console.WriteLine("Digitou: " + numeroConvertido);
            }
            catch (FormatException)
            {
                Console.WriteLine("Somente números são permitidos.");
            }
            catch (NumeroDeAzarException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro...");
            }

            Console.ReadKey();
        }
    }
}
