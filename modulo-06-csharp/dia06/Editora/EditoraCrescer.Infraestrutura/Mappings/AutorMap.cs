using EditoraCrescer.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace EditoraCrescer.Infraestrutura.Mappings
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autores");
            
            Property(p => p.Nome).HasMaxLength(300);
        }
    }
}
