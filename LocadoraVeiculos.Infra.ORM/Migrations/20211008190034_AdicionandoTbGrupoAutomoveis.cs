using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraVeiculos.Infra.ORM.Migrations
{
    public partial class AdicionandoTbGrupoAutomoveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGRUPOAUTOMOVEIS");
        }
    }
}
