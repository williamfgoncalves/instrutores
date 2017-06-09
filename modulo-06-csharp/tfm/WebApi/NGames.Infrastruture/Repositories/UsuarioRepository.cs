using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Data.Entity;
using System.Linq;

namespace NGames.Infrastruture.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly NGamesDataContext _context;

        public UsuarioRepository(NGamesDataContext context)
        {
            _context = context;
        }

        public void Criar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }
        public void Excluir(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Deleted;
        }

        public Usuario Obter(string email)
        {
            return _context.Usuarios
                .Include(u => u.Permissoes)
                .Where(u => u.Email == email)
                .FirstOrDefault();
        }
    }
}
