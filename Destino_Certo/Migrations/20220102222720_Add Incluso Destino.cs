using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destino_Certo.Migrations
{
    public partial class AddInclusoDestino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Incluso",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incluso",
                table: "Destinos");
        }
    }
}
