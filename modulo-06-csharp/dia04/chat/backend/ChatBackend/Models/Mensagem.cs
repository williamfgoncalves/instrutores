using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Mensagem
    {
        public Mensagem()
        {
            Timestamp = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public double Timestamp { get; private set; }
        public Usuario Usuario { get; set; }
        public string Texto { get; set; }
    }
}