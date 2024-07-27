using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_2_de_POO.Migrations
{
    /// <inheritdoc />
    public partial class atualizaciondata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numeroidentificador",
                schema: "dbo",
                table: "clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numeroidentificador",
                schema: "dbo",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
