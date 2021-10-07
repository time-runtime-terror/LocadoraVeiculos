using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM
{
    public class GrupoAutomoveisDbContext : DbContext
    {
        public DbSet<GrupoAutomoveis> GrupoAutomoveis { get; set; }

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GrupoAutomoveisDbContext).Assembly);
        }
    }
}
