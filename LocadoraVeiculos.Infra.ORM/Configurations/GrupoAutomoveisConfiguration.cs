using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class GrupoAutomoveisConfiguration : IEntityTypeConfiguration<GrupoAutomoveisEntity>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomoveisEntity> builder)
        {
            builder.ToTable("TBGRUPOAUTOMOVEIS");

            //criando chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeGrupo).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.PlanoDiarioUm).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.PlanoDiarioDois).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.KmControladoUm).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.KmControladoDois).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.KmControladoIncluida).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.KmLivreUm).HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
