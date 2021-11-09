using LocadoraVeiculos.netCore.Dominio.CupomModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class CupomConfiguration : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> entity)
        {
            entity.ToTable("TBCUPOM");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.DataValidade)
                .HasColumnType("date")
                .IsRequired();

            entity.Property(e => e.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            entity.Property(e => e.Valor)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.ValorMinimo)
                .HasDefaultValue(0)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(c => c.Parceiro)
                .WithMany(p => p.Cupons)
                .HasForeignKey(c => c.ParceiroId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
