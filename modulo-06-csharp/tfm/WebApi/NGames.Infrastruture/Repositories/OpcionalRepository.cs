using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Linq;
using System;
using System.Collections.Generic;

namespace NGames.Infrastruture.Repositories
{
    public class OpcionalRepository : IOpcionalRepository
    {
        readonly NGamesDataContext _context;

        public OpcionalRepository(NGamesDataContext context)
        {
            _context = context;
        }

        public List<Opcional> Listar()
        {
            return _context.Opcionais.OrderBy(o => o.Nome).ToList();
        }

        public Opcional Obter(int id)
        {
            return _context.Opcionais.Where(c => c.Id == id).FirstOrDefault();
        }

    }
}