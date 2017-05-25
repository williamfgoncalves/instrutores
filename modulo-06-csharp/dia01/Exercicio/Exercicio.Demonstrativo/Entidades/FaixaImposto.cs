namespace Exercicio.Demonstrativo.Entidades
{
    public class FaixaImposto
    {
        public FaixaImposto(double teto, double percentual)
        {
            Teto = teto;
            Aliquota = percentual;
        }
        public double Teto { get; private set; }
        public double Aliquota { get; private set; }
    }
}