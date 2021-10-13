using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.ORM.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCLIENTE");

            builder.HasKey(p => p.Id);

            builder
                .HasMany(c => c.Clientes)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId);

            builder
                .Property(p => p.Nome)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Email)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Telefone)
                .IsRequired();

            builder
                .Property(p => p.Endereco)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.NumeroCadastro)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.TipoCadastro)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.TemLocacaoAtiva)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(p => p.RG)
                .IsUnicode(false);

            builder
                .Property(p => p.CNH)
                .IsUnicode(false);

            builder
                .Property(p => p.VencimentoCnh);

        }
    }
}
