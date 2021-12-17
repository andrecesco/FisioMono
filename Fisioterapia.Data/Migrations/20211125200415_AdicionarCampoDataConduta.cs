using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fisioterapia.Data.Migrations
{
    public partial class AdicionarCampoDataConduta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConduta",
                table: "Condutas",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConduta",
                table: "Condutas");
        }
    }
}
