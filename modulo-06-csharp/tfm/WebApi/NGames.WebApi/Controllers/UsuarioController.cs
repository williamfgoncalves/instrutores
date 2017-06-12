using NGames.Domain.Entities;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using NGames.WebApi.Models;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Linq;

namespace NGames.WebApi.Controllers
{
    // Permite usuário não autenticados acessarem a controller
    [AllowAnonymous]
    [RoutePrefix("api/acessos")]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(NGamesDataContext context, IUsuarioRepository usuarioRepository) : base(context)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost, Route("registrar")]
        public HttpResponseMessage Registrar([FromBody]RegistrarUsuarioModel model)
        {
            var usuario = _usuarioRepository.Obter(model.Email);
            if (usuario == null)
            {
                usuario = new Usuario(model.Nome, model.Email, model.Senha);

                if (usuario.IsValid())
                {
                    _usuarioRepository.Criar(usuario);
                    Commit();
                }
                else
                {
                    return ResponderErro(usuario.Messages);
                }
            }
            else
            {
                return ResponderErro("Usuário já existe.");
            }

            return ResponderOK(new { usuario.Id });
        }

        [HttpPost, Route("resetarsenha")]
        public HttpResponseMessage ResetarSenha(string email)
        {
            var usuario = _usuarioRepository.Obter(email);
            if (usuario == null)
                return ResponderErro(new string[] { "Usuário não encontrado." });

            var novaSenha = usuario.ResetarSenha();

            if (usuario.IsValid())
            {
                _usuarioRepository.Alterar(usuario);
                Commit();
            }
            else
            {
                return ResponderErro(usuario.Messages);
            }

            return ResponderOK();
        }

        // Exige que o usuário se autentique
        [BasicAuthorization]
        [HttpGet, Route("usuario")]
        public HttpResponseMessage Obter()
        {
            // só pode obter as informações do usuário corrente (logado, autenticado)
            var usuario = _usuarioRepository.Obter(Thread.CurrentPrincipal.Identity.Name);

            if (usuario == null)
                return ResponderErro("Usuário não encontrado.");

            return ResponderOK(
                new
                {
                    usuario.Nome,
                    Permissoes = usuario.Permissoes.Select(p => new { p.Nome }).ToArray(),
                    usuario.Email
                });
        }
    }
}