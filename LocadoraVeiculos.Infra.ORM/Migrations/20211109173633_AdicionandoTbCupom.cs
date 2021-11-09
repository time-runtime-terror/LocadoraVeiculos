using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoTbCupom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupomId",
                table: "TBLOCACAO",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBCUPOM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false, defaultValue: 0m),
                    DataValidade = table.Column<DateTime>(type: "date", nullable: false),
                    ParceiroId = table.Column<int>(type: "int", nullable: true),
                    ValorMinimo = table.Column<decimal>(type: "decimal(18,0)", nullable: false, defaultValue: 0m),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCUPOM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCUPOM_TBPARCEIRO_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "TBPARCEIRO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBLOCACAO_CupomId",
                table: "TBLOCACAO",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCUPOM_ParceiroId",
                table: "TBCUPOM",
                column: "ParceiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLOCACAO_TBCUPOM_CupomId",
                table: "TBLOCACAO",
                column: "CupomId",
                principalTable: "TBCUPOM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLOCACAO_TBCUPOM_CupomId",
                table: "TBLOCACAO");

            migrationBuilder.DropTable(
                name: "TBCUPOM");

            migrationBuilder.DropIndex(
                name: "IX_TBLOCACAO_CupomId",
                table: "TBLOCACAO");

            migrationBuilder.DropColumn(
                name: "CupomId",
                table: "TBLOCACAO");
        }
    }
}
