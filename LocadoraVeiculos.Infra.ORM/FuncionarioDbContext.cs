using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace LocadoraVeiculos.Infra.ORM
{
    public class FuncionarioDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            string connectionString = config.Build().GetConnectionString("SqlServerEF");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuncionarioDbContext).Assembly);
        }
    }
}
