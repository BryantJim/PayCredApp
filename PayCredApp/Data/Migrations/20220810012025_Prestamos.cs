using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCredApp.Data.Migrations
{
    public partial class Prestamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPrestamos",
                columns: table => new
                {
                    IdTipoPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaGracias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrestamos", x => x.IdTipoPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "ePrestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    TasaInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoPrestamo = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BceCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BceInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsNulo = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ePrestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_ePrestamos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ePrestamos_TipoPrestamos_IdTipoPrestamo",
                        column: x => x.IdTipoPrestamo,
                        principalTable: "TipoPrestamos",
                        principalColumn: "IdTipoPrestamo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ePrestamos_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "dPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    FechaCuota = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoCuota = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BceCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BceInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dPrestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dPrestamos_ePrestamos_IdPrestamo",
                        column: x => x.IdPrestamo,
                        principalTable: "ePrestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dPrestamos_IdPrestamo",
                table: "dPrestamos",
                column: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_ePrestamos_IdCliente",
                table: "ePrestamos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ePrestamos_IdTipoPrestamo",
                table: "ePrestamos",
                column: "IdTipoPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_ePrestamos_ModificadoPor",
                table: "ePrestamos",
                column: "ModificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dPrestamos");

            migrationBuilder.DropTable(
                name: "ePrestamos");

            migrationBuilder.DropTable(
                name: "TipoPrestamos");
        }
    }
}
