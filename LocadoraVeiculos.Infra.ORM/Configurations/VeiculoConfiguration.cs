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

            builder.Property(v => v.Foto).HasColumnType("VARBINARY(MAX)").IsRequired();
            builder.Property(v => v.Placa).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(v => v.Modelo).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(v => v.Marca).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(v => v.TipoCombustivel).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(v => v.CapacidadeTanque).HasColumnType("INT").IsRequired();
            builder.Property(v => v.Quilometragem).HasColumnType("INT").IsRequired();
            builder.Property(v => v.EstaAlugado).HasColumnType("BIT").IsRequired();

            builder
              .HasOne(v => v.GrupoAutomoveis)
              .WithMany(g => g.Veiculos)
              .HasForeignKey(v => v.IdGrupoAutomoveis).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
