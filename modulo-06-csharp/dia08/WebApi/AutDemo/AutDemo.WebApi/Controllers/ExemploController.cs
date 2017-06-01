using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AutDemo.WebApi.Controllers
{
    public class ExemploController : ControllerBasica
    {
        public ExemploController()
        {
        }

        [HttpGet]
        public HttpResponseMessage Get(string nome)
        {
            return ResponderOK($"Acesso anônimo permitido. Usuário logado é {Thread.CurrentPrincipal.Identity.Name}");
        }

        [HttpGet, BasicAuthorization]
        public HttpResponseMessage Get(int id)
        {
            return ResponderOK($"Qualquer usuário autenticado pode acessar. Usuário logado é {Thread.CurrentPrincipal.Identity.Name}");
        }

        [HttpGet, BasicAuthorization(Roles = "Administradores,Colaboradores")]
        public HttpResponseMessage Get()
        {
            return ResponderOK($"Somente usuários do grupo Administradores podem acessar. Usuário logado é {Thread.CurrentPrincipal.Identity.Name}");
        }
    }
}