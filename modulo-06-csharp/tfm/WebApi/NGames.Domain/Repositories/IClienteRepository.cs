using NGames.Domain.Entities;

namespace NGames.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Criar(Cliente cliente);
        Cliente ObterPorCpf(string cpf);
        Cliente Obter(int id);
    }
}