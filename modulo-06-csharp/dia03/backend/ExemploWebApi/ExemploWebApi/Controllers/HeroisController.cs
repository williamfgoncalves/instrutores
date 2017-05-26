using ExemploWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExemploWebApi.Controllers
{
    public class HeroisController : ApiController
    {
        private static List<Heroi> herois = new List<Heroi>();
        private static int contador = 1;
        private static object @lock = new object();

        public IEnumerable<Heroi> Get(string nome = null, int? id = null)
        {
            return herois.Where(x => 
                (id == null || x.Id == id) &&
                (nome == null || x.Nome == nome)
            );
        }

        public IHttpActionResult Post(Heroi heroi)
        {
            if (heroi == null)
            {
                return BadRequest();
            }
            else
            {
                lock (@lock)
                {
                    herois.Add(heroi);
                    heroi.Id = contador++;
                }

                return Ok(heroi);
            }
        }

        //public HttpResponseMessage Post(Heroi heroi)
        //{
        //    if (heroi != null)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.Created);
        //    }
        //    else
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //}
    }
}
