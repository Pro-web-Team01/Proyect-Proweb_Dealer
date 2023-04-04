using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealer.Migrations
{
    public partial class Migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "condicion",
                table: "vehiculos_stock",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "condicion_vehiculo",
                columns: table => new
                {
                    id_condicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    condicion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__condicio__C9237400CCCF1079", x => x.id_condicion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_stock_condicion",
                table: "vehiculos_stock",
                column: "condicion");

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculo_condicion",
                table: "vehiculos_stock",
                column: "condicion",
                principalTable: "condicion_vehiculo",
                principalColumn: "id_condicion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculo_condicion",
                table: "vehiculos_stock");

            migrationBuilder.DropTable(
                name: "condicion_vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_vehiculos_stock_condicion",
                table: "vehiculos_stock");

            migrationBuilder.DropColumn(
                name: "condicion",
                table: "vehiculos_stock");
        }
    }
}
