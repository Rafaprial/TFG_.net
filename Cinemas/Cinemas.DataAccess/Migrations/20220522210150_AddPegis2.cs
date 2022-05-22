using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemasWeb.Migrations
{
    public partial class AddPegis2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EdadMax",
                table: "Pegis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EdadMax",
                table: "Pegis");
        }
    }
}
