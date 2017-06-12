using EditoraCrescer.Api.Models;
using EditoraCrescer.Dominio;
using EditoraCrescer.Infraestrutura;
using EditoraCrescer.Infraestrutura.Repositorios;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EditoraCrescer.Api.Controllers
{
    [RoutePrefix("api/livros")]
    public class LivrosController : ApiController
    {
        private readonly LivroRepositorio repositorio = new LivroRepositorio();

        // GET: api/livros
        [HttpGet]
        public IHttpActionResult ObterLivrosPublicadosExcetoLancamentos(int quantidadePular, int quantidadeTrazer)
        {
            var retornoPaginado = repositorio.ObterLivrosPublicadosExcetoLancamentos(quantidadePular, quantidadeTrazer);
            return Ok(new { dados = retornoPaginado });
        }

        [HttpGet]
        [Route("quantidadetotal")]
        public IHttpActionResult ObterQuantidadeLivrosPublicadosExcetoLancamentos()
        {
            var quantidade = repositorio.ObterQuantidadeLivrosPublicadosExcetoLancamentos();
            return Ok(new { dados = quantidade });
        }

        // GET: api/Livros
        [HttpGet]
        [Route("lancamentos")]
        public IHttpActionResult ObterLivrosLancamentos()
        {
            var livros = repositorio.ObterLivrosLancamentos();
            return Ok(new { dados = livros });
        }

        // GET: api/Livros/2
        [HttpGet]
        [Route("{isbn:int}")]
        public IHttpActionResult ObterLivro(int isbn)
        {
            var livro = repositorio.ObterPorIsbn(isbn);
            return Ok(new { dados = livro });
        }

        [HttpGet]
        [Route("{genero}")]
        public IHttpActionResult ObterLivroPorGenero(string genero)
        {
            var livro = repositorio.ObterPorGenero(genero);
            return Ok(new { dados = livro });
        }

        //PUT: api/Livros/4
        [HttpPut]
        [Route("{isbn}")]
        public HttpResponseMessage EditarLivro(int isbn, Livro livro)
        {
            if (isbn != livro.Isbn)
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new { mensagens = new string[] { "Ids não conferem" } });

            if (!repositorio.VerificaSeLivroExiste(isbn))
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new { mensagens = new string[] { "Livro não encontrado" } });

            repositorio.AlterarLivro(livro);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST: api/Livros
        [HttpPost]
        public IHttpActionResult IncluirLivro(LivroModel model)
        {
            //var autor = repositorioAutor.ObterAutorPorId();
            var autor = new Autor("blabla");

            var livro = new Livro(model.Isbn, model.Titulo, model.Descricao, model.Genero, autor);
            repositorio.IncluirLivro(livro);

            return Ok(new { dados = livro });
        }

        [HttpPost]
        [Route("revisar/{isbn}")]
        public IHttpActionResult RevisarLivro(int isbn, int idRevisor)
        {
            var livro = repositorio.ObterPorIsbn(isbn);
            //var autor = repositorioAutor.ObterAutorPorId();
            var revisor = new Revisor("blabla");
            livro.Revisar(revisor);

            repositorio.AlterarLivro(livro);

            return Ok(new { dados = livro });
        }

        [HttpPost]
        [Route("publicar/{isbn}")]
        public IHttpActionResult PublicarLivro(int isbn)
        {
            var livro = repositorio.ObterPorIsbn(isbn);
            livro.Publicar(new NotificacaoAssinantes());
            repositorio.AlterarLivro(livro);

            return Ok(new { dados = livro });
        }

        // DELETE: api/Livros/5
        [HttpDelete]
        [Route("{isbn}")]
        public HttpResponseMessage ExcluirLivro(int isbn)
        {
            var livro = repositorio.ObterPorIsbn(isbn);
            if (livro == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new { mensagens = new string[] { "Livro não encontrado" } });

            repositorio.ExcluirLivro(livro);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            repositorio.Dispose();
            base.Dispose(disposing);
        }
    }
}
