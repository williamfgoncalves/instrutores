using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    [RoutePrefix("api/pacotes")]
    [BasicAuthorization]
    public class PacoteController : ControllerBase
    {
        readonly IPacoteRepository _pacoteRepository;

        public PacoteController(NGamesDataContext context, IPacoteRepository pacoteRepository) : base(context)
        {
            _pacoteRepository = pacoteRepository;
        }

        [HttpGet, Route]
        public HttpResponseMessage Get()
        {
            return ResponderOK(_pacoteRepository.Listar());
        }        
    }
}