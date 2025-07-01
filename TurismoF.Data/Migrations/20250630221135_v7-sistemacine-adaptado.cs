using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v7sistemacineadaptado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_Reservas_ReservaId",
                table: "Boletos");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_Viajes_ViajeId",
                table: "Boletos");

            migrationBuilder.AlterColumn<int>(
                name: "ViajeId",
                table: "Boletos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "Boletos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_Reservas_ReservaId",
                table: "Boletos",
                column: "ReservaId",
                principalTable: "Reservas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_Viajes_ViajeId",
                table: "Boletos",
                column: "ViajeId",
                principalTable: "Viajes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_Reservas_ReservaId",
                table: "Boletos");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletos_Viajes_ViajeId",
                table: "Boletos");

            migrationBuilder.AlterColumn<int>(
                name: "ViajeId",
                table: "Boletos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReservaId",
                table: "Boletos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_Reservas_ReservaId",
                table: "Boletos",
                column: "ReservaId",
                principalTable: "Reservas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletos_Viajes_ViajeId",
                table: "Boletos",
                column: "ViajeId",
                principalTable: "Viajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
