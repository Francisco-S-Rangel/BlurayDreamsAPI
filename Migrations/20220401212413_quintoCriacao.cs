using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlurayDreamsAPI.Migrations
{
    public partial class quintoCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "precoProduto",
                table: "PedidoProdutos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precoProduto",
                table: "PedidoProdutos");
        }
    }
}
