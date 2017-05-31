using EditoraCrescer.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoraCrescer.Infraestrutura.Repositorios
{
    public class LivroRepositorio : IDisposable
    {
        private Contexto contexto;
        public LivroRepositorio()
        {
            contexto = new Contexto();
        }

        public object ObterTodos()
        {
            //Exemplo de como incluir dependencias

            //return contexto.Livros
            //                .Include(x => x.Autor)
            //                .Include(x => x.Revisor)
            //                .ToList();

            return contexto.Livros
                           .Select(x => new
                           {
                               Isbn = x.Isbn,
                               Titulo = x.Titulo,
                               NomeAutor = x.Autor.Nome,
                               Genero = x.Genero
                           })
                           .ToList();
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
