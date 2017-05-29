using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ChatsController : ApiController
    {
        public static List<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

        public IEnumerable<Mensagem> GetAllChats()
        {
            return Mensagens.OrderByDescending(x => x.Timestamp).Take(10);
        }

        [HttpPost]
        public HttpResponseMessage EnviarMensagem(Mensagem mensagem)
        {
            if (mensagem != null)
            {
                Mensagens.Add(mensagem);
                
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
