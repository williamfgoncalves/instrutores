
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGames.Domain.Entities;

namespace NGames.Domain.UnitTest
{
    [TestClass]
    public class ReservaUnitTest
    {
        [TestMethod]
        public void Criar_Reserva_Valida()
        {
            var reserva = CriarReservaValida();
            Assert.IsTrue(reserva.IsValid());
            Assert.AreEqual(163M, reserva.TotalReserva);
            Assert.AreEqual(99, reserva.Produto.Quantidade);
            Assert.AreEqual(0, reserva.Opcionais[0].Opcional.Quantidade);
            Assert.AreEqual(1, reserva.Opcionais[1].Opcional.Quantidade);
            Assert.AreEqual(2, reserva.Opcionais[2].Opcional.Quantidade);
        }

        private Reserva CriarReservaValida()
        {
            var cliente =
               new Cliente("Cliente Teste",
               "00000000000",
               new DateTime(1990, 12, 31),
               Genero.NaoInformado,
               "Av. Theodomiro Porto da Fonseca,3101, Centro",
               "São Leopoldo",
               "RS",
               "000000");

            var reserva = new Reserva(cliente, 1);

            reserva.SelecionarProduto(new Produto("PS3", 100, 100));
            reserva.SelecionarPacote(new Pacote("Finde: 2 Jogos + 1 Controle", 7, 70));
            reserva.SelecionarOpcional(new Opcional("Game FIFA 2017 - PS3", 1, 10), 1);
            reserva.SelecionarOpcional(new Opcional("Game Mortal Kombat - PS3", 2, 10), 1);
            reserva.SelecionarOpcional(new Opcional("Controle", 3, 50), 1);

            return reserva;
        }
    }
}
