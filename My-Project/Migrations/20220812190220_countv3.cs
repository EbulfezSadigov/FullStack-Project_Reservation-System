using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Project.Migrations
{
    public partial class countv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartCount",
                table: "Guests",
                newName: "startCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startCount",
                table: "Guests",
                newName: "StartCount");
        }
    }
}
