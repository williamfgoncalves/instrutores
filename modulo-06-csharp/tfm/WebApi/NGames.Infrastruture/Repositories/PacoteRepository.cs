using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Linq;
using System;
using System.Collections.Generic;

namespace NGames.Infrastruture.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        readonly NGamesDataContext _context;

        public PacoteRepository(NGamesDataContext context)
        {
            _context = context;
        }

        List<Pacote> IPacoteRepository.Listar()
        {
            return _context.Pacote.ToList();
        }

        Pacote IPacoteRepository.Obter(int id)
        {
            return _context.Pacote.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}