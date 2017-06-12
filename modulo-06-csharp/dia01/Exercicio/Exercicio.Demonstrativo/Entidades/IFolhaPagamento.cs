using Exercicio.Demonstrativo.Entidades;

namespace Crescer.Exercicio3
{
    public interface IFolhaPagamento
    {
        Demonstrativo GerarDemonstrativo(int horasCategoria, double salarioBase, double horasExtras, double horasDescontadas);
    }
}