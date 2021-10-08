using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoTbCliente : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_TBCLIENTE_EmpresaId",
                table: "TBCLIENTE",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCLIENTE");

            migrationBuilder.DropTable(
                name: "TBFUNCIONARIO");
        }
    }
}
