using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    [RoutePrefix("api/opcionais")]
    [BasicAuthorization]
    public class OpcionalController : ControllerBase
    {
        readonly IOpcionalRepository _opcionalRepository;

        public OpcionalController(NGamesDataContext context, IOpcionalRepository opcionalRepository) : base(context)
        {
            _opcionalRepository = opcionalRepository;
        }

        [HttpGet, Route]
        public HttpResponseMessage Get()
        {
            return ResponderOK(_opcionalRepository.Listar());
        }        
    }
}