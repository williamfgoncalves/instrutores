using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class OpcionalMap : EntityTypeConfiguration<Opcional>
    {
        public OpcionalMap()
        {
            ToTable("Opcional");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Diaria)
                .IsRequired();

            Property(p => p.Nome)
                .HasMaxLength(256)
                .IsRequired();

            Property(p => p.Quantidade)
                .IsRequired();
        }
    }
}
