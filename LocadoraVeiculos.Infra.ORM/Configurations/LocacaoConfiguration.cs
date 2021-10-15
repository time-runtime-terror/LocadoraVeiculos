using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLOCACAO");

            builder.HasKey(l => l.Id);

            builder // Taxas
                .HasMany(l => l.Taxas);

            builder // Cliente
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Locacoes)
                .HasForeignKey(l => l.ClienteId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder // Veículo
                .HasOne(v => v.Veiculo)
                .WithMany(v => v.Locacoes)
                .HasForeignKey(l => l.VeiculoId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder
                .Ignore(l => l.Veiculo);

            builder
                .Property(p => p.DataSaida)
                .IsRequired();

            builder
                .Property(p => p.DataDevolucao)
                .IsRequired();

            builder
                .Property(p => p.Caucao)
                .IsRequired();

            builder
                .Property(p => p.Total)
                .IsRequired();

            builder
                .Property(p => p.Plano)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Devolucao)
                .HasDefaultValue("Pendente")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Condutor)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
