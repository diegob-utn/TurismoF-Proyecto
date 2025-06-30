using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v5Rutagooglemaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorMapa",
                table: "Rutas");

            migrationBuilder.RenameColumn(
                name: "Coordenadas",
                table: "Rutas",
                newName: "colorRuta");

            migrationBuilder.RenameColumn(
                name: "NumeroVagon",
                table: "Asientos",
                newName: "Numero");

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

            migrationBuilder.AddColumn<string>(
                name: "Fila",
                table: "Asientos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Fila",
                table: "Asientos");

            migrationBuilder.RenameColumn(
                name: "colorRuta",
                table: "Rutas",
                newName: "Coordenadas");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Asientos",
                newName: "NumeroVagon");

            migrationBuilder.AddColumn<string>(
                name: "ColorMapa",
                table: "Rutas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
