﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    [DbContext(typeof(LocadoraDbContext))]
    [Migration("20211014181153_AdicionandoTabelaLocacao")]
    partial class AdicionandoTabelaLocacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocacaoTaxasServicos", b =>
                {
                    b.Property<int>("LocacoesId")
                        .HasColumnType("int");

                    b.Property<int>("TaxasId")
                        .HasColumnType("int");

                    b.HasKey("LocacoesId", "TaxasId");

                    b.HasIndex("TaxasId");

                    b.ToTable("LocacaoTaxasServicos");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.ClienteModule.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNH")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("NumeroCadastro")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RG")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TemLocacaoAtiva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("TipoCadastro")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("VencimentoCnh")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("TBCLIENTE");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.FuncionarioModule.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("DATE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Salario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBFUNCIONARIO");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule.GrupoAutomoveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KmControladoDois")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("KmControladoIncluida")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("KmControladoUm")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("KmLivreUm")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NomeGrupo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("PlanoDiarioDois")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("PlanoDiarioUm")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TBGRUPOAUTOMOVEIS");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Caucao")
                        .HasColumnType("float");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Condutor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Devolucao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("Pendente");

                    b.Property<string>("Plano")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBLOCACAO");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.TaxasServicosModule.TaxasServicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocalServico")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("OpcaoServico")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Servico")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<double>("Taxa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TBTAXASSERVICOS");
                });

            modelBuilder.Entity("LocacaoTaxasServicos", b =>
                {
                    b.HasOne("LocadoraVeiculos.netCore.Dominio.LocacaoModule.Locacao", null)
                        .WithMany()
                        .HasForeignKey("LocacoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.netCore.Dominio.TaxasServicosModule.TaxasServicos", null)
                        .WithMany()
                        .HasForeignKey("TaxasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.ClienteModule.Cliente", b =>
                {
                    b.HasOne("LocadoraVeiculos.netCore.Dominio.ClienteModule.Cliente", "Empresa")
                        .WithMany("Clientes")
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.LocacaoModule.Locacao", b =>
                {
                    b.HasOne("LocadoraVeiculos.netCore.Dominio.ClienteModule.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraVeiculos.netCore.Dominio.ClienteModule.Cliente", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
