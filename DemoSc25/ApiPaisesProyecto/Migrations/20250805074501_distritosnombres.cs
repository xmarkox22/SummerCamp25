using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPaisesProyecto.Migrations
{
    /// <inheritdoc />
    public partial class distritosnombres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionJuntaDistrital",
                table: "Distritos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Responsable",
                table: "Distritos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionJuntaDistrital",
                table: "Distritos");

            migrationBuilder.DropColumn(
                name: "Responsable",
                table: "Distritos");
        }
    }
}
