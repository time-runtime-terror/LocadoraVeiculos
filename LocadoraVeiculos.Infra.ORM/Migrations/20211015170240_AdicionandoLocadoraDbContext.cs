using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoLocadoraDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCLIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Endereco = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCadastro = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NumeroCadastro = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CNH = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    VencimentoCnh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RG = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    TemLocacaoAtiva = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCLIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCLIENTE_TBCLIENTE_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "TBCLIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBFUNCIONARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DATE", nullable: false),
                    Salario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFUNCIONARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGRUPOAUTOMOVEIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGrupo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    PlanoDiarioUm = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    PlanoDiarioDois = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    KmControladoUm = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    KmControladoDois = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    KmControladoIncluida = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    KmLivreUm = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGRUPOAUTOMOVEIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTAXASSERVICOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servico = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    OpcaoServico = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    LocalServico = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTAXASSERVICOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBVEICULO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foto = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false),
                    Placa = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "INT", nullable: false),
                    Quilometragem = table.Column<int>(type: "INT", nullable: false),
                    IdGrupoAutomoveis = table.Column<int>(type: "int", nullable: true),
                    EstaAlugado = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVEICULO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVEICULO_TBGRUPOAUTOMOVEIS_IdGrupoAutomoveis",
                        column: x => x.IdGrupoAutomoveis,
                        principalTable: "TBGRUPOAUTOMOVEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBLOCACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Caucao = table.Column<double>(type: "float", nullable: false),
                    Plano = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Condutor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Devolucao = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Pendente"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLOCACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBCLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCLIENTE",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLOCACAO_TBVEICULO_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVEICULO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocacaoTaxasServicos",
                columns: table => new
                {
                    LocacoesId = table.Column<int>(type: "int", nullable: false),
                    TaxasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoTaxasServicos", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_LocacaoTaxasServicos_TBLOCACAO_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLOCACAO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoTaxasServicos_TBTAXASSERVICOS_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTAXASSERVICOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoTaxasServicos_TaxasId",
                table: "LocacaoTaxasServicos",
                column: "TaxasId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCLIENTE_EmpresaId",
                table: "TBCLIENTE",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_ClienteId",
                table: "TBLOCACAO",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_VeiculoId",
                table: "TBLOCACAO",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVEICULO_IdGrupoAutomoveis",
                table: "TBVEICULO",
                column: "IdGrupoAutomoveis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxasServicos");

            migrationBuilder.DropTable(
                name: "TBFUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TBLOCACAO");

            migrationBuilder.DropTable(
                name: "TBTAXASSERVICOS");

            migrationBuilder.DropTable(
                name: "TBCLIENTE");

            migrationBuilder.DropTable(
                name: "TBVEICULO");

            migrationBuilder.DropTable(
                name: "TBGRUPOAUTOMOVEIS");
        }
    }
}
