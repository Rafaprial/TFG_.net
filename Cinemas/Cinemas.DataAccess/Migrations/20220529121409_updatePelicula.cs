using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemasWeb.Migrations
{
    public partial class updatePelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Peliculas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Peliculas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
