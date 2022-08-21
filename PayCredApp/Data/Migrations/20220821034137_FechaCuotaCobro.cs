using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCredApp.Data.Migrations
{
    public partial class FechaCuotaCobro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCuota",
                table: "dCobros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCuota",
                table: "dCobros");
        }
    }
}
