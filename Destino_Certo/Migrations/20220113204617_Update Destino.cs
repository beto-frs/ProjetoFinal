using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destino_Certo.Migrations
{
    public partial class UpdateDestino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CidadeEstado",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadeEstado",
                table: "Destinos");
        }
    }
}
