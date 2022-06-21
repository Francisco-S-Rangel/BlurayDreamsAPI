using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlurayDreamsAPI.Migrations
{
    public partial class pequenamudancaempedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Trocas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_PedidoId",
                table: "Trocas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trocas_Pedido_PedidoId",
                table: "Trocas",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trocas_Pedido_PedidoId",
                table: "Trocas");

            migrationBuilder.DropIndex(
                name: "IX_Trocas_PedidoId",
                table: "Trocas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Trocas");
        }
    }
}
