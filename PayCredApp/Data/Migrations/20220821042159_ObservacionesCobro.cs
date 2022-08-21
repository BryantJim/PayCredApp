using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCredApp.Data.Migrations
{
    public partial class ObservacionesCobro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "eCobros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "eCobros");
        }
    }
}
