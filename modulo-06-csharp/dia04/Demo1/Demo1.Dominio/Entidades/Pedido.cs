﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<ItemPedido> Itens { get; set; }

        public Pedido()
        {
            Itens = new List<ItemPedido>();
        }

        public bool Validar(out List<string> mensagens)
        {
            mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(NomeCliente))
                mensagens.Add("Nome do cliente deve ser informado.");

            if (Itens.Where(i => i.Quantidade < 0).Any())
                mensagens.Add("Não é possível gerar pedido com itens que contenham quantidade negativa.");

            return mensagens.Count() == 0;
        }
    }
}
