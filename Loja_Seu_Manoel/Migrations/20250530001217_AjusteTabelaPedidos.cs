using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja_Seu_Manoel.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_PedidoJson",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_PedidoJson",
                table: "Pedidos");
        }
    }
}
