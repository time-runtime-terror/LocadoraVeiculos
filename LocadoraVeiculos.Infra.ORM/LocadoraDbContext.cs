﻿using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace LocadoraVeiculos.Infra.ORM
{
    public class LocadoraDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraDbContext).Assembly);
        }
    }
}
