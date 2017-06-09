using NGames.Domain.Entities;
using NGames.Infrastruture.Mappings;
using System.Data.Entity;

namespace NGames.Infrastruture.Context
{
    public class NGamesDataContext : DbContext
    {
        public NGamesDataContext() : base("NGamesConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }        
        public DbSet<Opcional> Opcionais { get; set; }
        public DbSet<Pacote> Pacote { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ReservaOpcional> ReservaOpcionais { get; set; }
        public DbSet<Produto> Produtos { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new OpcionalMap());
            modelBuilder.Configurations.Add(new PacoteMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            modelBuilder.Configurations.Add(new ReservaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ReservaOpcionalMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }
    }
}
