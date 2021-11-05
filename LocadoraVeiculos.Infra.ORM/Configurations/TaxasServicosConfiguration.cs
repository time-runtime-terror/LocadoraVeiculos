using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class TaxasServicosConfiguration : IEntityTypeConfiguration<TaxasServicos>
    {
        public void Configure(EntityTypeBuilder<TaxasServicos> builder)
        {
            builder.ToTable("TBTAXASSERVICOS");

            builder.HasKey(p => p.Id);

            builder.HasMany(l => l.Locacoes);

            builder
                .Property(p => p.Servico)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Taxa)
                .IsRequired();

            builder
                .Property(p => p.LocalServico)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.OpcaoServico)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
