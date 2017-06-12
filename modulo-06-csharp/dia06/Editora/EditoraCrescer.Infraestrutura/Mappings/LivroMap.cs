using EditoraCrescer.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace EditoraCrescer.Infraestrutura.Mappings
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livros");

            HasKey(x => x.Isbn);

            HasRequired(x => x.Autor)
                .WithMany()
                //.HasForeignKey(x => x.IdAutor)
                .Map(x => x.MapKey("IdAutor"));

            HasOptional(x => x.Revisor)
                .WithMany()
                //.HasForeignKey(x => x.IdRevisor)
                .Map(x => x.MapKey("IdRevisor"));
        }
    }
}
