using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlurayDreamsAPI.Migrations
{
    public partial class quartaCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupomTroca",
                table: "Clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CupomTroca",
                table: "Clientes");
        }
    }
}
