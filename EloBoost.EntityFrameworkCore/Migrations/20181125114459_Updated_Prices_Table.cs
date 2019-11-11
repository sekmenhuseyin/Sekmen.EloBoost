using Microsoft.EntityFrameworkCore.Migrations;

namespace EloBoost.Migrations
{
    public partial class Updated_Prices_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDivision",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "CurrentLeague",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "DesiredDivision",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "DesiredLeague",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Prices",
                newName: "Price");

            migrationBuilder.AddColumn<byte>(
                name: "DivisionType",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "LeagueType",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Order",
                table: "Prices",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DivisionType",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "LeagueType",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Prices",
                newName: "Amount");

            migrationBuilder.AddColumn<byte>(
                name: "CurrentDivision",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "CurrentLeague",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DesiredDivision",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DesiredLeague",
                table: "Prices",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
