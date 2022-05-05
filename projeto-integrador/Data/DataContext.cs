using Microsoft.EntityFrameworkCore;
using projeto_integrador.Models;
using System.Linq;

namespace projeto_integrador.Data
{
    public class DataContext : DbContext
    {
        //tem que navegar até o diretorio fisico da infra (infra.shared.data)
        //dotnet ef --startup-project ../api.app migrations add inicial  (na pasta data)
        //dotnet ef --startup-project ../api.app database update

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost;Database=projeto-integrador-db;Port=5432;User Id=admin;Password=Senh@123;");
        //}

        public DbSet<UsuarioContratante> UsuarioContratante { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }

    }
}
