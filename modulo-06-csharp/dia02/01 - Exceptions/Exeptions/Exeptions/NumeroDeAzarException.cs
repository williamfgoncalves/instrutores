using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exeptions
{
    public class NumeroDeAzarException : Exception
    {
        public NumeroDeAzarException() : base("Número 13 é um número de azar")
        {
        }
    }


}
