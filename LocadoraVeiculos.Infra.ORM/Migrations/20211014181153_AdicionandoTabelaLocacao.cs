using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoTabelaLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_TBLOCACAO_ClienteId",
                table: "TBLOCACAO",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoTaxasServicos");

            migrationBuilder.DropTable(
                name: "TBLOCACAO");
        }
    }
}
