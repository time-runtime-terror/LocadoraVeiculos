using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class SolicitacaoEmailConfiguration : IEntityTypeConfiguration<SolicitacaoEmail>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoEmail> builder)
        {
            builder.ToTable("TBSOLICITACAO_EMAIL");

            builder.HasKey(s => s.Id);

            builder
                .HasOne(s => s.Locacao)
                .WithMany(l => l.SolicitacoesEmail)
                .HasForeignKey(s => s.LocacaoId);

            builder
                .Property(s => s.CaminhoRecibo)
                .IsRequired();

            builder
                .Property(s => s.EnvioPendente)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
