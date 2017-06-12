using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using NGames.WebApi.Models;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    [RoutePrefix("api/clientes")]
    [BasicAuthorization]
    public class ClienteController : ControllerBase
    {
        readonly IClienteRepository _clienteRepository;

        public ClienteController(NGamesDataContext context, IClienteRepository clienteRepository) : base(context)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost, Route]
        public HttpResponseMessage Post([FromBody]CriarClienteModel model)
        {
            var cliente = _clienteRepository.ObterPorCpf(model.Cpf);

            if (cliente == null)
            {
                cliente =
                    new Cliente(model.Nome,
                    model.Cpf,
                    model.DtNascimento,
                    model.Genero,
                    model.Logradouro,
                    model.Nome,
                    model.Estado,
                    model.Cep);

                if (cliente.IsValid())
                {
                    _clienteRepository.Criar(cliente);
                    Commit();
                }
                else
                {
                    return ResponderErro(cliente.Messages);
                }
            }
            else
            {
                return ResponderErro("Cliente já existe.");
            }

            return ResponderOK(new { cliente.Id });
        }

        [HttpGet, Route]
        public HttpResponseMessage Get(string cpf)
        {
            return ResponderOK(_clienteRepository.ObterPorCpf(cpf));
        }
    }
}