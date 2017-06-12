using NGames.Domain.Entities;
using System.Collections.Generic;

namespace NGames.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Produto Obter(int id);

        List<Produto> Listar();
    }
}