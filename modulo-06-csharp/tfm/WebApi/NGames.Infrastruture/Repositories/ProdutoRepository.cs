using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Linq;
using System;
using System.Collections.Generic;

namespace NGames.Infrastruture.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        readonly NGamesDataContext _context;

        public ProdutoRepository(NGamesDataContext context)
        {
            _context = context;
        }

        public List<Produto> Listar()
        {
            return _context.Produtos.ToList();
        }

        Produto IProdutoRepository.Obter(int id)
        {
            return _context.Produtos.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}