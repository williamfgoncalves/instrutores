using EditoraCrescer.Infraestrutura;
using EditoraCrescer.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new Contexto())
            {
                //var autor = contexto.Autores.FirstOrDefault(x => x.Nome == "Fabricio da Silva");

                var autor = new Autor() { Id = 7, Nome = "Fabricio da Silva" };
                autor.Nome = "Fabricio Elias Rissetto da Silva";
                //contexto.Entry(autor).State = System.Data.Entity.EntityState.Added;

                //contexto.Entry(autor).State = System.Data.Entity.EntityState.Detached;

                contexto.Entry(autor).State = System.Data.Entity.EntityState.Modified;

                contexto.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
