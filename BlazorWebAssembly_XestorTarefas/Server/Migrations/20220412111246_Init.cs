using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWebAssembly_XestorTarefas.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarefaItem",
                columns: table => new
                {
                    TarefaItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefaItem", x => x.TarefaItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarefaItem");
        }
    }
}
