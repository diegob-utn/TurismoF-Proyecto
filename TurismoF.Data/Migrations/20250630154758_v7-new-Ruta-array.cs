using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v7newRutaarray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatFin",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "LatInicio",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "LonFin",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "LonInicio",
                table: "Rutas");

            migrationBuilder.RenameColumn(
                name: "colorRuta",
                table: "Rutas",
                newName: "UbicacionInicio");

            migrationBuilder.AddColumn<string>(
                name: "UbicacionFin",
                table: "Rutas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UbicacionFin",
                table: "Rutas");

            migrationBuilder.RenameColumn(
                name: "UbicacionInicio",
                table: "Rutas",
                newName: "colorRuta");

            migrationBuilder.AddColumn<double>(
                name: "LatFin",
                table: "Rutas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LatInicio",
                table: "Rutas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LonFin",
                table: "Rutas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LonInicio",
                table: "Rutas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
