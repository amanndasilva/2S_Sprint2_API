using Microsoft.EntityFrameworkCore.Migrations;

namespace Aula6_EfCore.Migrations
{
    public partial class ALterTablePedidosItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PedidosItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PedidosItem");
        }
    }
}
