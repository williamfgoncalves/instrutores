using NGames.Domain.Entities;
using System.Collections.Generic;

namespace NGames.Domain.Repositories
{
    public interface IPacoteRepository
    {
        Pacote Obter(int id);
        List<Pacote> Listar();
    }
}