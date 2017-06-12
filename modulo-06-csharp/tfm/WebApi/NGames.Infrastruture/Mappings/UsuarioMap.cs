using NGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace NGames.Infrastruture.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasMaxLength(60)
                .IsRequired();

            Property(p => p.Email)
                .HasMaxLength(160)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Usuario_Email", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.Senha)
                .HasMaxLength(32)
                .IsFixedLength();

            HasMany(x => x.Permissoes)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable("UsuarioPermisao");
                    x.MapLeftKey("IdUsuario");
                    x.MapRightKey("IdPermissao");
                });
        }
    }
}
