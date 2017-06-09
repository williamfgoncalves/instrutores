using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class ReservaOpcionalMap : EntityTypeConfiguration<ReservaOpcional>
    {
        public ReservaOpcionalMap()
        {
            ToTable("ReservaOpcional");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Quantidade)
                .IsRequired();

            HasRequired(p => p.Opcional)
                .WithMany()
                .Map(x => x.MapKey("IdOpcional"));

            HasRequired(p => p.Reserva)
                .WithMany(x => x.Opcionais)
                .Map(x => x.MapKey("IdReserva"));
        }
    }
}
