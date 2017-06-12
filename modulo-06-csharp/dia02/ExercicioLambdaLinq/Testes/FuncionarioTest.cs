using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Repositorio;
using Newtonsoft.Json;

namespace Testes
{
    [TestClass]
    public class FuncionarioTest
    {        
        private const string CARGO_DESENVOLVEDOR_JUNIOR = "Desenvolvedor Júnior";

        //BuscarPorCargo
        [TestMethod]
        public void BuscarDesenvolvedoresPorCargo()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<Funcionario> funcionariosPorCargo = repositorioFuncionarios.BuscarPorCargo(new Cargo(CARGO_DESENVOLVEDOR_JUNIOR, 190));

            Assert.AreEqual(8, funcionariosPorCargo.Count);
        }

        //OrdenadosPorCargo
        [TestMethod]
        public void FuncionariosOrdenadosPorCargo()
        {
            var dbFuncionarios = new RepositorioFuncionarios();

            IList<Funcionario> funcionariosOrdenadosPorCargo = dbFuncionarios.OrdenadosPorCargo();

            var resultadoEsperado = new int[]
            {
                3,
                8,
                5,
                1,
                2,
                7,
                4,
                6,
                9,
                10,
                11
            };

            var resultado = JsonConvert.SerializeObject(funcionariosOrdenadosPorCargo);
            Assert.IsTrue(funcionariosOrdenadosPorCargo.Select(x => x.Id).SequenceEqual(resultadoEsperado));
        }

        //BuscarPorNome
        [TestMethod]
        public void BuscouFuncionarioPorNome()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();

            IList<Funcionario> funcionarios = repositorioFuncionarios.BuscarPorNome("Zuck");

            Assert.AreEqual(1, funcionarios.Count);
            Assert.AreEqual("Mark Zuckerberg", funcionarios[0].Nome);
        }

        //BuscarPorTurno        
        [TestMethod]
        public void BuscaPorTurnoManhaRetorna5Registros()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<Funcionario> funcionariosManha = repositorioFuncionarios.BuscarPorTurno(TurnoTrabalho.Manha);

            Assert.AreEqual(5, funcionariosManha.Count);
        }

        [TestMethod]
        public void BuscaPorTurnoManhaETardeRetorna9Registros()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<Funcionario> funcionariosManha = repositorioFuncionarios.BuscarPorTurno(TurnoTrabalho.Manha, TurnoTrabalho.Tarde);

            Assert.AreEqual(9, funcionariosManha.Count);
        }        

        //FiltrarPorIdadeAproximada
        [TestMethod]
        public void BuscarFuncionariosProximosDe30AnosRetorna4Registros()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<Funcionario> funcionariosIdadeAprox = repositorioFuncionarios.FiltrarPorIdadeAproximada(30);

            Assert.AreEqual(5, funcionariosIdadeAprox.Count);
        }

        //SalarioMedio
        [TestMethod]
        public void SalarioMedioTurnoManhaEh274_1()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            double salarioMedioManha = repositorioFuncionarios.SalarioMedio(TurnoTrabalho.Manha);

            Assert.AreEqual(274.1, salarioMedioManha);
        }

        [TestMethod]
        public void SalarioMedioTodosOsFuncionarioEh233_68181818181819()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            double salarioMedioManha = repositorioFuncionarios.SalarioMedio();

            Assert.AreEqual(233.68181818181819, salarioMedioManha);
        }

        //AniversariantesDoMes
        [TestMethod]
        public void AniversariantesDoMes()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();

            IList<Funcionario> aniversariantes = repositorioFuncionarios.AniversariantesDoMes();
            int mesAtual = DateTime.Now.Month;

            foreach (Funcionario funcionario in aniversariantes)
            {
                Assert.AreEqual(mesAtual, funcionario.DataNascimento.Month);
            }
        }

        //BuscaRapida
        [TestMethod]
        public void BuscaRapidaRetorna10Resultados()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<dynamic> buscaRapida = repositorioFuncionarios.BuscaRapida();

            Assert.AreEqual(11, buscaRapida.Count);
            Assert.AreEqual("Marcelinho Carioca", buscaRapida[0].NomeFuncionario);
            Assert.AreEqual(CARGO_DESENVOLVEDOR_JUNIOR, buscaRapida[0].TituloCargo);
        }

        //QtdFuncionariosPorTurno
        [TestMethod]
        public void BuscaQuantidadePorCargo()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();
            IList<dynamic> quantidadeFuncionariosPorTurno = repositorioFuncionarios.QuantidadeFuncionariosPorTurno();

            Assert.AreEqual(TurnoTrabalho.Manha, quantidadeFuncionariosPorTurno[0].Turno);
            Assert.AreEqual(5, quantidadeFuncionariosPorTurno[0].Quantidade);

            Assert.AreEqual(TurnoTrabalho.Tarde, quantidadeFuncionariosPorTurno[1].Turno);
            Assert.AreEqual(4, quantidadeFuncionariosPorTurno[1].Quantidade);

            Assert.AreEqual(TurnoTrabalho.Noite, quantidadeFuncionariosPorTurno[2].Turno);
            Assert.AreEqual(2, quantidadeFuncionariosPorTurno[2].Quantidade);
        }

        //FuncionarioMaisComplexo
        [TestMethod]
        public void FuncionarioMaisComplexoEhDollynhoDeveloper()
        {
            var repositorioFuncionarios = new RepositorioFuncionarios();

            dynamic funcionarioComplex = repositorioFuncionarios.FuncionarioMaisComplexo();
            Assert.AreEqual("Dollynho Developer", funcionarioComplex.Nome);
            Assert.AreEqual("10/10/1980", funcionarioComplex.DataNascimento);
            Assert.AreEqual("R$ 550,50", funcionarioComplex.SalarioRS);
            Assert.AreEqual("$550.50", funcionarioComplex.SalarioUS);
            Assert.AreEqual(1, funcionarioComplex.QuantidadeMesmoCargo);
        }
    }
}
