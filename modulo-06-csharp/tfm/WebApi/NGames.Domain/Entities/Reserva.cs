using System;
using System.Linq;
using System.Collections.Generic;

namespace NGames.Domain.Entities
{
    public class Reserva : EntityBase
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public Produto Produto { get; private set; }
        public Pacote Pacote { get; private set; }
        public List<ReservaOpcional> Opcionais { get; private set; }
        public decimal TotalReserva { get; private set; }
        public decimal TotalOpcionais { get; private set; }
        public decimal TotalPago { get; private set; }
        public DateTime DtReserva { get; private set; }
        public DateTime DtEntrega { get; private set; }
        public int Diarias { get; private set; }
        public decimal Multa { get; private set; }

        // EF
        protected Reserva()
        {
        }

        public Reserva(Cliente cliente, int diarias)
        {
            Cliente = cliente;
            DtReserva = DateTime.Now;
            Diarias = diarias;
            Opcionais = new List<ReservaOpcional>();

            if (Cliente == null)
                AddMessage("Cliente inválido.");

            if (Diarias < 1)
                AddMessage("Diária inválido.");

            DtEntrega = DateTime.Today.AddDays(diarias);
        }

        public void SelecionarProduto(Produto produto)
        {
            if (Produto != null)
            {
                TotalReserva -= Produto.Diaria;
                produto.AdicionarEstoque(1);
            }

            Produto = produto;

            if (Produto == null)
            {
                AddMessage("Produto inválido.");
                return;
            }

            TotalReserva += produto.Diaria;
            produto.BaixarEstoque(1);
        }

        public void SelecionarPacote(Pacote pacote)
        {
            if (Pacote != null)
                TotalReserva += Pacote.Desconto;

            Pacote = pacote;

            if (pacote == null)
            {
                AddMessage("Pacote inválido.");
                return;
            }

            TotalReserva -= pacote.Desconto;
        }

        public void SelecionarOpcional(Opcional opcional, int quantidade)
        {
            var reservaOpcional = new ReservaOpcional(this, opcional, quantidade);
            Opcionais.Add(reservaOpcional);
            TotalReserva += reservaOpcional.Opcional.Diaria;
            reservaOpcional.Opcional.BaixarEstoque(reservaOpcional.Quantidade);
            TotalOpcionais += reservaOpcional.Opcional.Diaria;
        }

        public void RemoverOpcional(int idOpcional)
        {
            var reservaOpcional = Opcionais.Where(i => i.Id == idOpcional).FirstOrDefault();

            if (reservaOpcional == null)
            {
                AddMessage("Opcional inválido");
                return;
            }

            Opcionais.Remove(reservaOpcional);

            TotalReserva -= reservaOpcional.Opcional.Diaria;

            reservaOpcional.Opcional.AdicionarEstoque(reservaOpcional.Quantidade);

            TotalOpcionais -= reservaOpcional.Opcional.Diaria;
        }

        public void Pagar()
        {
            CalcularMulta();
            TotalPago = TotalReserva + Multa;
        }

        private void CalcularMulta()
        {
            decimal media = TotalReserva / Diarias;
            if (DtEntrega > DateTime.Today)
                Multa = media * ((decimal)DateTime.Today.Subtract(DtEntrega).TotalDays);
        }
        private void Calcular(Opcional opcional)
        {
            TotalReserva += opcional.Diaria;
        }
    }
}
