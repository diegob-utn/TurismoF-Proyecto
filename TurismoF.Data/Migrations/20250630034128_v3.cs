using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurismoF.Data.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsPreferencial",
                table: "Vagones",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CantidadAsientosPorVagon",
                table: "Trenes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadVagones",
                table: "Trenes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroVagon",
                table: "Asientos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsPreferencial",
                table: "Vagones");

            migrationBuilder.DropColumn(
                name: "CantidadAsientosPorVagon",
                table: "Trenes");

            migrationBuilder.DropColumn(
                name: "CantidadVagones",
                table: "Trenes");

            migrationBuilder.DropColumn(
                name: "NumeroVagon",
                table: "Asientos");
        }
    }
}
