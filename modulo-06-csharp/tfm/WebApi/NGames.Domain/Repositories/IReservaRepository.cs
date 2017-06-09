using NGames.Domain.Entities;

namespace NGames.Domain.Repositories
{
    public interface IReservaRepository
    {
        void Criar(Reserva cliente);
    }
}