using NGames.Domain.Entities;

namespace NGames.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        void Alterar(Usuario usuario);
        void Criar(Usuario usuario);
        void Excluir(Usuario usuario);
        Usuario Obter(string email);
    }
}