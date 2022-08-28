using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Project.Migrations
{
    public partial class detailroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DetailText1",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailText2",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PeopleCount",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DetailText1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DetailText2",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PeopleCount",
                table: "Rooms");
        }
    }
}
