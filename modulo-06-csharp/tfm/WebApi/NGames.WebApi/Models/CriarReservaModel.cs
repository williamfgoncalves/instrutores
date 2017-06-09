using NGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGames.WebApi.Models
{
    public class CriarReservaModel
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int IdPacote { get; set; }
        public List<OpcionalModel> Opcionais { get; set; }
        public int Diarias { get; set; }
    }
}