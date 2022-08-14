using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCredApp.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    IdProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.IdProvincia);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

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
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    EsNulo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Ciudades_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudades",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincias",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
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
                    Saldo = table.Column<bool>(type: "bit", nullable: false),
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
                        principalColumn: "IdUsuario");
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

            migrationBuilder.CreateTable(
                name: "eCobros",
                columns: table => new
                {
                    IdCobro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapitalCobrado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InteresCobrado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoraCobrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsNulo = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPor = table.Column<int>(type: "int", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eCobros", x => x.IdCobro);
                    table.ForeignKey(
                        name: "FK_eCobros_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eCobros_ePrestamos_IdPrestamo",
                        column: x => x.IdPrestamo,
                        principalTable: "ePrestamos",
                        principalColumn: "IdPrestamo");
                    table.ForeignKey(
                        name: "FK_eCobros_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "dCobros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCobro = table.Column<int>(type: "int", nullable: false),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false),
                    NoCuota = table.Column<int>(type: "int", nullable: false),
                    CapitalCobrado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InteresCobrado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoraCobrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dCobros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dCobros_eCobros_IdCobro",
                        column: x => x.IdCobro,
                        principalTable: "eCobros",
                        principalColumn: "IdCobro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdCiudad",
                table: "Clientes",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdProvincia",
                table: "Clientes",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ModificadoPor",
                table: "Clientes",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_dCobros_IdCobro",
                table: "dCobros",
                column: "IdCobro");

            migrationBuilder.CreateIndex(
                name: "IX_dPrestamos_IdPrestamo",
                table: "dPrestamos",
                column: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_eCobros_IdCliente",
                table: "eCobros",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_eCobros_IdPrestamo",
                table: "eCobros",
                column: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_eCobros_ModificadoPor",
                table: "eCobros",
                column: "ModificadoPor");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dCobros");

            migrationBuilder.DropTable(
                name: "dPrestamos");

            migrationBuilder.DropTable(
                name: "eCobros");

            migrationBuilder.DropTable(
                name: "ePrestamos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoPrestamos");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
