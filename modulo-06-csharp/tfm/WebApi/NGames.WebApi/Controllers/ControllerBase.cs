using NGames.Infrastruture.Context;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NGames.WebApi.Controllers
{
    public class ControllerBase : ApiController
    {
        readonly NGamesDataContext _context;
        public ControllerBase(NGamesDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public HttpResponseMessage ResponderOK(object result = null)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { result });
        }

        public HttpResponseMessage ResponderErro(params string[] errors)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors });
        }

        public HttpResponseMessage ResponderErro(IEnumerable<string> errors)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors });
        }
    }
}