using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class ReservaMap : EntityTypeConfiguration<Reserva>
    {
        public ReservaMap()
        {
            ToTable("Reserva");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Cliente);

            HasOptional(x => x.Produto);

            HasOptional(p => p.Pacote);

            //HasMany(p => p.Opcionais)
            //    .WithMany()
            //    .Map(x =>
            //    {
            //        x.ToTable("ReservaOpcional");
            //        x.MapLeftKey("IdReserva");
            //        x.MapRightKey("IdOpcional");
            //    });

            Property(p => p.TotalReserva)
                .IsRequired();

            Property(p => p.TotalPago);

            Property(p => p.DtEntrega)
                .IsRequired();

            Property(p => p.DtReserva)
                .IsRequired();

            Property(p => p.Diarias)
            .IsRequired();

            Property(p => p.Multa);
        }
    }
}
