using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EditoraCrescer.Dominio;

namespace EditoraCrescer.Testes
{
    [TestClass]
    public class LivroTest
    {
        [TestMethod]
        public void LivroCriadoNaoDeveEstarRevisadoNemPublicado()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));

            Assert.IsFalse(livro.EstaRevisado);
            Assert.IsFalse(livro.EstaPublicado);
        }

        [TestMethod]
        public void LivroRevisadoDevePossuirDataRevisaoERevisor()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            var revisor = new Revisor("revisor");

            livro.Revisar(revisor);
            Assert.IsNotNull(livro.DataRevisao);
            Assert.IsNotNull(livro.Revisor);
            Assert.IsTrue(livro.EstaRevisado);
        }

        [TestMethod]
        public void LivroPublicadoDevePossuirDataPublicacao()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            var revisor = new Revisor("revisor");

            livro.Revisar(revisor);
            livro.Publicar(new NotificacaoAssinanteFake());

            Assert.IsNotNull(livro.DataPublicacao);
            Assert.IsTrue(livro.EstaPublicado);
        }

        [TestMethod]
        public void LivroPublicadoDeveDispararNotificacaoParaAssinantes()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            var revisor = new Revisor("revisor");
            var notificacao = new NotificacaoAssinanteFake();

            livro.Revisar(revisor);
            livro.Publicar(notificacao);

            Assert.IsTrue(notificacao.NotificouUsuario);
        }

        [TestMethod]
        [ExpectedException(typeof(RegraNegocioException), "Não é possível revisar um livro duas vezes.")]
        public void LivroNaoPodeSerRevisadoDuasVezes()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            var revisor = new Revisor("revisor");

            livro.Revisar(revisor);
            livro.Revisar(revisor);
        }

        [TestMethod]
        [ExpectedException(typeof(RegraNegocioException), "O livro já foi publicado. Não é possível publicá-lo novamente pois isso alteraria sua data de publicação.")]
        public void LivroNaoPodeSerPublicadoDuasVezes()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            var revisor = new Revisor("revisor");

            livro.Revisar(revisor);
            livro.Publicar(new NotificacaoAssinanteFake());
            livro.Publicar(new NotificacaoAssinanteFake());
        }

        [TestMethod]
        [ExpectedException(typeof(RegraNegocioException), "O livro deve estar revisado.")]
        public void LivroNaoPodeSerPublicadoSemEstarRevisado()
        {
            var livro = new Livro(1, "titulo", "descricao", "genero", new Autor("nome"));
            
            livro.Publicar(new NotificacaoAssinanteFake());
        }
    }
}
