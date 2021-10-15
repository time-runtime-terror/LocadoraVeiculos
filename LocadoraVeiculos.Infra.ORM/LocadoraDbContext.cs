using LocadoraVeiculos.Infra.ORM.Configurations;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LocadoraVeiculos.Infra.ORM
{
    public class LocadoraDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoAutomoveis> GrupoAutomoveis { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<TaxasServicos> Taxas { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            string connectionString = config.Build().GetConnectionString("SqlServerEF");

            optionsBuilder
                .UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromMilliseconds(10), null);
                }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoAutomoveisConfiguration());
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            modelBuilder.ApplyConfiguration(new TaxasServicosConfiguration());
            modelBuilder.ApplyConfiguration(new LocacaoConfiguration());
        }
    }
}
