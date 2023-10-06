using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastros.Migrations
{
    /// <inheritdoc />
    public partial class Cadastros2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pedido",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "ItemPedido",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Endereco",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Endereco");
        }
    }
}
