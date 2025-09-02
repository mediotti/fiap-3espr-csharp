using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLoja.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Id_ClienteId",
                table: "Pedidos",
                columns: new[] { "Id", "ClienteId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_Id_ClienteId",
                table: "Pedidos");
        }
    }
}
