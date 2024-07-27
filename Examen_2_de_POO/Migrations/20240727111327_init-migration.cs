using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_2_de_POO.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "clientes",
                schema: "dbo",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numeroidentificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montoprestamo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tasacomision = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tasainteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Termino = table.Column<int>(type: "int", nullable: false),
                    Fechadesembolso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fechaprimerpago = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Planamortiguacion",
                schema: "dbo",
                columns: table => new
                {
                    PlanamortizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numeroinstalacion = table.Column<int>(type: "int", nullable: false),
                    Fechapago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagoNivelSinSVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagoNivelSconSVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balanceprincipal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planamortiguacion", x => x.PlanamortizacionId);
                    table.ForeignKey(
                        name: "FK_Planamortiguacion_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planamortiguacion_ClienteId",
                schema: "dbo",
                table: "Planamortiguacion",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planamortiguacion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "clientes",
                schema: "dbo");
        }
    }
}
