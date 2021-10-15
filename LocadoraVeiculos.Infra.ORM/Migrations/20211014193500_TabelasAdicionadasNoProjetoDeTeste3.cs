using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class TabelasAdicionadasNoProjetoDeTeste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVEICULO_TBGRUPOAUTOMOVEIS_IdGrupoAutomoveis",
                table: "TBVEICULO");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVEICULO_TBGRUPOAUTOMOVEIS_IdGrupoAutomoveis",
                table: "TBVEICULO",
                column: "IdGrupoAutomoveis",
                principalTable: "TBGRUPOAUTOMOVEIS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBVEICULO_TBGRUPOAUTOMOVEIS_IdGrupoAutomoveis",
                table: "TBVEICULO");

            migrationBuilder.AddForeignKey(
                name: "FK_TBVEICULO_TBGRUPOAUTOMOVEIS_IdGrupoAutomoveis",
                table: "TBVEICULO",
                column: "IdGrupoAutomoveis",
                principalTable: "TBGRUPOAUTOMOVEIS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
