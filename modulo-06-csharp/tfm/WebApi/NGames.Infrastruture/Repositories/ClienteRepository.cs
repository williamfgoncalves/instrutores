using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Linq;

namespace NGames.Infrastruture.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        readonly NGamesDataContext _context;

        public ClienteRepository(NGamesDataContext context)
        {
            _context = context;
        }

        public void Criar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public Cliente Obter(int id)
        {
            return _context.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _context.Clientes.Where(c => c.Cpf == cpf).FirstOrDefault();
        }
    }
}