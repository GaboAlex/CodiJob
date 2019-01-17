using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodiJobService.Migrations.CodiJobDb
{
    public partial class RowVersionToProyect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "t_proyecto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "t_proyecto");
        }
    }
}
