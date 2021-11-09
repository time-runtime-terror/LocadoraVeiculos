using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class MudandoCupom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCUPOM_TBPARCEIRO_ParceiroId",
                table: "TBCUPOM");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCUPOM_TBPARCEIRO_ParceiroId",
                table: "TBCUPOM",
                column: "ParceiroId",
                principalTable: "TBPARCEIRO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBCUPOM_TBPARCEIRO_ParceiroId",
                table: "TBCUPOM");

            migrationBuilder.AddForeignKey(
                name: "FK_TBCUPOM_TBPARCEIRO_ParceiroId",
                table: "TBCUPOM",
                column: "ParceiroId",
                principalTable: "TBPARCEIRO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
