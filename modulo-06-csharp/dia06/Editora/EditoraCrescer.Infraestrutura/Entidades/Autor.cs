using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoraCrescer.Infraestrutura.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
