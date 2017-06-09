namespace NGames.Domain.Entities
{
    public class ReservaOpcional : EntityBase
    {
        public int Id { get; private set; }
        public Reserva Reserva { get; private set; }
        public Opcional Opcional { get; private set; }
        public int Quantidade { get; private set; }

        // EF
        protected ReservaOpcional() { }

        public ReservaOpcional(Reserva reserva, Opcional opcional, int quantidade)
        {
            Reserva = reserva;
            Opcional = opcional;
            Quantidade = quantidade;

            if (Quantidade < 1)
                AddMessage("Quanitade inválido.");
        }
    }
}
