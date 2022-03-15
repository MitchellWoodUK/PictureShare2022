using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PictureShare_.Data.Migrations
{
    public partial class @public : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Public",
                table: "Pictures");
        }
    }
}
