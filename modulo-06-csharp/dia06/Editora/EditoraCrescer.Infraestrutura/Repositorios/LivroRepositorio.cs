using EditoraCrescer.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EditoraCrescer.Infraestrutura.Repositorios
{
    public class LivroRepositorio : IDisposable
    {
        private Contexto contexto = new Contexto();
        private Expression<Func<Livro, dynamic>> camposBasicos =
                (x => new
                {
                    Isbn = x.Isbn,
                    Titulo = x.Titulo,
                    NomeAutor = x.Autor.Nome,
                    Genero = x.Genero
                });
        private DateTime seteDiasAtras = DateTime.Now.Date.Subtract(new TimeSpan(7, 0, 0, 0, 0));

        public object ObterLivrosLancamentos()
        {
            return contexto.Livros
                           .Where(x => x.DataPublicacao != null &&
                                DbFunctions.TruncateTime(x.DataPublicacao.Value) >= seteDiasAtras)
                           .OrderByDescending(x => x.DataPublicacao)
                           .Select(camposBasicos)
                           .ToList();
        }

        public dynamic ObterLivrosPublicadosExcetoLancamentos(int quantidadePular, int quantidadeTrazer)
        {
            var livrosPublicados = contexto.Livros
                            .Where(x => x.DataPublicacao != null &&
                                DbFunctions.TruncateTime(x.DataPublicacao.Value) < seteDiasAtras);

            var livrosPaginados = livrosPublicados
                    .OrderByDescending(x => x.DataPublicacao) //precisa pro skip!
                    .Skip(quantidadePular)
                    .Take(quantidadeTrazer)
                    .Select(x => new
                    {
                        Isbn = x.Isbn,
                        Titulo = x.Titulo,
                        NomeAutor = x.Autor.Nome,
                        Genero = x.Genero
                    });

            //Essas variáveis acima contém queries que ainda não foram submetidas ao banco
            return new
            {
                livros = livrosPaginados.ToList(), //Uma query submetida aqui
                quantidadeTotal = livrosPublicados.Count() //Outra aqui
            };

            //Exemplo de como incluir dependencias

            //return contexto.Livros
            //                .Include(x => x.Autor)
            //                .Include(x => x.Revisor)
            //                .ToList();
        }

        public Livro ObterPorIsbn(int isbn)
        {
            return contexto.Livros.FirstOrDefault(x => x.Isbn == isbn);
        }

        public bool VerificaSeLivroExiste(int isbn)
        {
            return contexto.Livros.Count(e => e.Isbn == isbn) > 0;
        }

        public void AlterarLivro(Livro livro)
        {
            contexto.Entry(livro).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void IncluirLivro(Livro livro)
        {
            contexto.Livros.Add(livro);
            contexto.SaveChanges();
        }

        public List<Livro> ObterPorGenero(string genero)
        {
            return contexto.Livros
                            .Where(x => x.Genero.Contains(genero))
                            .ToList();
        }

        public void ExcluirLivro(Livro livro)
        {
            contexto.Livros.Remove(livro);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
