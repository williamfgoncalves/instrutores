using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;

namespace NGames.Infrastruture.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        readonly NGamesDataContext _context;

        public ReservaRepository(NGamesDataContext context)
        {
            _context = context;
        }

        public void Criar(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
        }
    }
}