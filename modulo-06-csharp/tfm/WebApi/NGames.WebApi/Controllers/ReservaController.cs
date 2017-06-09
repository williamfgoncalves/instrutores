using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using NGames.WebApi.Models;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    [RoutePrefix("api/reservas")]
    public class ReservaController : ControllerBase
    {
        readonly IReservaRepository _reservaRepository;
        readonly IClienteRepository _clienteRepository;
        readonly IProdutoRepository _produtoRepository;
        readonly IPacoteRepository _pacoteRepository;
        readonly IOpcionalRepository _opcionalRepository;

        public ReservaController(
            NGamesDataContext context,
            IClienteRepository clienteRepository,
            IProdutoRepository produtoRepository,
            IPacoteRepository pacoteRepository,
            IOpcionalRepository opcionalRepository,
            IReservaRepository reservaRepository) : base(context)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _pacoteRepository = pacoteRepository;
            _opcionalRepository = opcionalRepository;
            _reservaRepository = reservaRepository;
        }

        [HttpPost, Route]
        public HttpResponseMessage Post([FromBody]CriarReservaModel model)
        {
            var reserva = CriarReserva(model);
            if (reserva.IsValid())
            {
                _reservaRepository.Criar(reserva);
                Commit();
            }
            else
            {
                return ResponderErro(reserva.Messages);
            }

            return ResponderOK(new { reserva.Id });
        }

        [HttpPost, Route("calcular")]
        public HttpResponseMessage Calcular([FromBody]CriarReservaModel model)
        {
            var reserva = CriarReserva(model);

            return ResponderOK(new
            {
                TotalProduto = reserva.Produto == null ? 0 : reserva.Produto.Diaria,
                TotalPacote = reserva.Pacote == null ? 0 : reserva.Pacote.Valor,
                TotalDescontos = reserva.Pacote == null ? 0 : reserva.Pacote.Desconto,
                reserva.TotalReserva,
                reserva.TotalOpcionais
            });
        }

        Reserva CriarReserva(CriarReservaModel model)
        {
            var cliente = _clienteRepository.Obter(model.IdCliente);

            var reserva = new Reserva(cliente, model.Diarias);

            var produto = _produtoRepository.Obter(model.IdProduto);
            reserva.SelecionarProduto(produto);

            var pacote = _pacoteRepository.Obter(model.IdPacote);
            reserva.SelecionarPacote(pacote);

            foreach (var opcionalModel in model.Opcionais)
            {
                var opcional = _opcionalRepository.Obter(opcionalModel.IdOpcional);
                reserva.SelecionarOpcional(opcional, 1);
            }

            return reserva;
        }
    }
}