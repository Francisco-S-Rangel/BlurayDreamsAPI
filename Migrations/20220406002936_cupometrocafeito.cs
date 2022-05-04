using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlurayDreamsAPI.Migrations
{
    public partial class cupometrocafeito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Credito",
                table: "Clientes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Cupoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    TamanhoDesconto = table.Column<double>(type: "double precision", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trocas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    PedidoProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    RecebimentoProduto = table.Column<bool>(type: "boolean", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trocas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trocas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trocas_PedidoProdutos_PedidoProdutoId",
                        column: x => x.PedidoProdutoId,
                        principalTable: "PedidoProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_ClienteId",
                table: "Trocas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_PedidoProdutoId",
                table: "Trocas",
                column: "PedidoProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupoms");

            migrationBuilder.DropTable(
                name: "Trocas");

            migrationBuilder.DropColumn(
                name: "Credito",
                table: "Clientes");
        }
    }
}
