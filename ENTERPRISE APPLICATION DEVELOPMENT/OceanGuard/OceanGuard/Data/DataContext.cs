using Microsoft.EntityFrameworkCore;
using OceanGuard.Entities;

namespace OceanGuard.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Autoridade> Autoridades { get; set;}
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<OcorrenciaLixo> OcorrenciasLixo { get; set;}
        public DbSet<EventoNatural> EventosNaturais { get; set;}
        public DbSet<DensidadeBanhista> DensidadeBanhistas { get; set;}
        public DbSet<Notificacao> Notificacoes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
        }
    }
}
