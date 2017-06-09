using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using NGames.WebApi.Models;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    [RoutePrefix("api/produtos")]
    [BasicAuthorization]
    public class ProdutoController : ControllerBase
    {
        readonly IProdutoRepository _produtoRepository;

        public ProdutoController(NGamesDataContext context, IProdutoRepository produtoRepository) : base(context)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet, Route]
        public HttpResponseMessage Get()
        {
            return ResponderOK(_produtoRepository.Listar());
        }        
    }
}