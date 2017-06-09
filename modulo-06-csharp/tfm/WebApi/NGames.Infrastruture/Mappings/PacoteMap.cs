using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class PacoteMap : EntityTypeConfiguration<Pacote>
    {
        public PacoteMap()
        {
            ToTable("Pacote");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasMany(p => p.Opcionais)
            //    .WithMany()
            //    .Map(x =>
            //    {
            //        x.ToTable("PacoteOpcional");
            //        x.MapLeftKey("IdPacote");
            //        x.MapRightKey("IdOpcional");
            //    });

            Property(p => p.Desconto)
                .IsRequired();

            Property(p => p.Valor)
                .IsRequired();

            Property(p => p.Nome)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
