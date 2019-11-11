using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EloBoost.Migrations
{
    public partial class Updated_Users_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "AbpUsers",
                nullable: false,
                defaultValueSql: "newid()",
                type: "UNIQUEIDENTIFIER ROWGUIDCOL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "AbpUsers");
        }
    }
}
