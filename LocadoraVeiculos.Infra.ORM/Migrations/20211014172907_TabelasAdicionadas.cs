using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class TabelasAdicionadas : Migration
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCLIENTE_EmpresaId",
                table: "TBCLIENTE",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVEICULO_IdGrupoAutomoveis",
                table: "TBVEICULO",
                column: "IdGrupoAutomoveis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCLIENTE");

            migrationBuilder.DropTable(
                name: "TBFUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TBVEICULO");

            migrationBuilder.DropTable(
                name: "TBGRUPOAUTOMOVEIS");
        }
    }
}
