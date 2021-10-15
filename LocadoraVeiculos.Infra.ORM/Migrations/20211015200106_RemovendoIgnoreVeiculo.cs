using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class RemovendoIgnoreVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLOCACAO_TBVEICULO_VeiculoId",
                table: "TBLOCACAO");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLOCACAO_TBVEICULO_VeiculoId",
                table: "TBLOCACAO",
                column: "VeiculoId",
                principalTable: "TBVEICULO",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBLOCACAO_TBVEICULO_VeiculoId",
                table: "TBLOCACAO");

            migrationBuilder.AddForeignKey(
                name: "FK_TBLOCACAO_TBVEICULO_VeiculoId",
                table: "TBLOCACAO",
                column: "VeiculoId",
                principalTable: "TBVEICULO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
