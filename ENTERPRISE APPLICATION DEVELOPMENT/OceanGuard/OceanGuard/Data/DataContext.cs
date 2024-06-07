using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanGuard.Entities;

namespace OceanGuard.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Autoridade> Autoridades { get; set;}
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<OcorrenciaLixo> OcorrenciasLixo { get; set;}
        public DbSet<EventoNatural> EventosNaturais { get; set;}
        public DbSet<DensidadeBanhista> DensidadeBanhistas { get; set;}
        public DbSet<Notificacao> Notificacoes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var boolToIntConverter = new BoolToZeroOneConverter<Int32>();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(boolToIntConverter);
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
