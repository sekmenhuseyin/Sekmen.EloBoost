using Microsoft.EntityFrameworkCore.Migrations;

namespace EloBoost.Migrations
{
    public partial class Updated_Users_Added_Credit_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Credit",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "AbpUsers");
        }
    }
}
