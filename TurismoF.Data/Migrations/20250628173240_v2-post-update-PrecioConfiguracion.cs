using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2postupdatePrecioConfiguracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreciosConfiguracion_Rutas_RutaId",
                table: "PreciosConfiguracion");

            migrationBuilder.AlterColumn<int>(
                name: "RutaId",
                table: "PreciosConfiguracion",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_PreciosConfiguracion_Rutas_RutaId",
                table: "PreciosConfiguracion",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreciosConfiguracion_Rutas_RutaId",
                table: "PreciosConfiguracion");

            migrationBuilder.AlterColumn<int>(
                name: "RutaId",
                table: "PreciosConfiguracion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PreciosConfiguracion_Rutas_RutaId",
                table: "PreciosConfiguracion",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
