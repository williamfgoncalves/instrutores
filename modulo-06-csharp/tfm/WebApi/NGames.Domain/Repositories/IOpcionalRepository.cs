using NGames.Domain.Entities;
using System.Collections.Generic;

namespace NGames.Domain.Repositories
{
    public interface IOpcionalRepository
    {
        Opcional Obter(int id);

        List<Opcional> Listar();
    }
}