using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EditoraCrescer.Api.Models
{
    public class LivroModel
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public int IdAutor { get; set; }
    }
}