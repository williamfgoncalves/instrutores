using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasMaxLength(60)
                .IsRequired();

            Property(p => p.Cpf)
                .HasMaxLength(11)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Cliente_Cpf", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.DtNascimento)
                .IsRequired();

            Property(x => x.Genero)
                .IsRequired();

            Property(x => x.Endereco.Cep)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Endereco.Cidade)
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.Endereco.Estado)
                .IsRequired()
                .HasMaxLength(2);

            Property(x => x.Endereco.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(x => x.Endereco.Logradouro)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
