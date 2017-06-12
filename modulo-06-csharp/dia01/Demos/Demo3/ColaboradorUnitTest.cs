using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo3.Entidades;

namespace Demo3
{
    [TestClass]
    public class ColaboradorUnitTest
    {
        [TestMethod]
        public void Deve_Criar_Um_Colaborador_Valido()
        {
            var colaborador = new Colaborador("Giovani Decusati", 12345.67, Cargo.Desenvolvedor);

            Assert.IsNotNull(colaborador.Cargo);
            Assert.IsNotNull(colaborador.Id);
            Assert.IsNotNull(colaborador.Nome);
            Assert.AreEqual(colaborador.Nome,"Giovani Decusati");
            Assert.IsNotNull(colaborador.SalarioBase);
        }
    }
}
