using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM
{
    public class FuncionarioDbContext : DbContext
    {
        public DbSet<FuncionarioEntity> Funcionarios {get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBLocadoraVeiculosEntity");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuncionarioDbContext).Assembly);
        }
    }
}
