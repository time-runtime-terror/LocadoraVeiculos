using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<FuncionarioEntity>
    {
        public void Configure(EntityTypeBuilder<FuncionarioEntity> builder)
        {
            builder.ToTable("TBFUNCIONARIO");

            //criando chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.NomeUsuario).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.DataEntrada).HasColumnType("DATE").IsRequired();
            builder.Property(p => p.Salario).HasColumnType("VARCHAR(50)").IsRequired();

        }
    }
}
