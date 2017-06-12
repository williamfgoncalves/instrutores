using Crescer.Exercicio3;
using System;

namespace Exercicio.Demonstrativo.Entidades
{
    public class FolhaPagamento : IFolhaPagamento
    {
        readonly FaixaImposto[] _inss = new FaixaImposto[]
        {
            new FaixaImposto(double.MaxValue, 0.10),
            new FaixaImposto(1500.00, 0.09),
            new FaixaImposto(1000.00, 0.08),
        };

        readonly FaixaImposto[] _irrf = new FaixaImposto[]
        {
            new FaixaImposto(double.MaxValue, 0.275),
            new FaixaImposto(4271.60, 0.225),
            new FaixaImposto(3418.60, 0.15),
            new FaixaImposto(2563.92, 0.075),
            new FaixaImposto(1710.79, 0),
        };

        public Demonstrativo GerarDemonstrativo(int horasCategoria, double salarioBase, double horasExtras, double horasDescontadas)
        {
            double valorHora = salarioBase / horasCategoria;

            var salario_Base = salarioBase;

            var hcExtras = new HorasCalculadas(horasExtras, TruncarValor(horasExtras * valorHora));

            var hcDescontadas = new HorasCalculadas(horasDescontadas, TruncarValor(horasDescontadas * valorHora));

            double totalProventos = salario_Base + hcExtras.ValorTotalHoras - hcDescontadas.ValorTotalHoras;

            Desconto inss = CalcularInss(totalProventos);

            Desconto irrf = CalcularIrrf(totalProventos - inss.Valor);

            double totalDescontos = inss.Valor + irrf.Valor;

            var totalLiquido = TruncarValor(totalProventos - totalDescontos);

            var fgts = new Desconto(0.11, TruncarValor(totalProventos * 0.11));

            return new Demonstrativo(
                salario_Base,
                horasCategoria,
                hcExtras,
                hcDescontadas,
                totalProventos,
                inss,
                irrf,
                totalDescontos,
                totalLiquido,
                fgts);
        }

        private Desconto CalcularInss(double totalProventos)
        {
            Desconto desconto = null;
            foreach (var faixa in _inss)
                if (totalProventos <= faixa.Teto)
                    desconto = new Desconto(faixa.Aliquota, TruncarValor(totalProventos * faixa.Aliquota));

            return desconto;
        }

        private Desconto CalcularIrrf(double totalProventos)
        {
            Desconto desconto = null;
            foreach (var faixa in _irrf)
                if (totalProventos < faixa.Teto)
                    desconto = new Desconto(faixa.Aliquota, TruncarValor(totalProventos * faixa.Aliquota));

            return desconto;
        }

        private double TruncarValor(double valor)
        {
            return Math.Truncate(valor * 100) / 100;
        }
    }
}

