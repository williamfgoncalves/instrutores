using System;

namespace EditoraCrescer.Dominio
{
    public class Livro
    {
        public int Isbn { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Genero { get; private set; }
        public DateTime? DataPublicacao { get; private set; }
        public Autor Autor { get; private set; } //IdAutor sumiu :) é questão de infra
        public Revisor Revisor { get; private set; } //IdRevisor sumiu :) é questão de infra
        public DateTime? DataRevisao { get; private set; }

        protected Livro() { } //EF :(

        public Livro(int isbn, string titulo, string descricao, string genero, Autor autor)
        {
            Isbn = isbn;
            Titulo = titulo;
            Descricao = descricao;
            Genero = genero;
            Autor = autor;
        }

        public void Alterar(int isbn, string titulo, string descricao, string genero, Autor autor)
        {
            Isbn = isbn;
            Titulo = titulo;
            Descricao = descricao;
            Genero = genero;
            Autor = autor;
        }

        public void Revisar(Revisor revisor)
        {
            if (EstaRevisado)
                throw new RegraNegocioException("Não é possível revisar um livro duas vezes.");

            Revisor = revisor;
            DataRevisao = DateTime.UtcNow;
        }

        public void Publicar(INotificacaoAssinantes notificacao)
        {
            if (!EstaRevisado)
                throw new RegraNegocioException("O livro deve estar revisado.");

            if (EstaPublicado)
                throw new RegraNegocioException("O livro já foi publicado. Não é possível publicá-lo novamente pois isso alteraria sua data de publicação.");

            DataPublicacao = DateTime.UtcNow;
            notificacao.NotificarNovaPublicacao($"O livro {this.Titulo} foi publicado. Venha conferir!");
        }

        public bool EstaRevisado
        {
            get { return DataRevisao != null && Revisor != null; }
        }

        public bool EstaPublicado
        {
            get { return DataPublicacao != null; }
        }
    }
}
