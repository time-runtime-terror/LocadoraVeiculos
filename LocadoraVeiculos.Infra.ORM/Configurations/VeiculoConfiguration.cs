using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVEICULO");

            //criando chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Imagem).HasColumnType("VARBINARY(MAX)").IsRequired();
            builder.Property(p => p.Placa).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Modelo).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Marca).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.TipoCombustivel).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.CapacidadeTanque).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Quilometragem).HasColumnType("INT").IsRequired();
            builder.Property(p => p.EstaAlugado).HasColumnType("BIT").IsRequired();
        }
    }
}
