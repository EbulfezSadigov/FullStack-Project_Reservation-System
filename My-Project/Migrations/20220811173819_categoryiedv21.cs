using Microsoft.EntityFrameworkCore.Migrations;

namespace My_Project.Migrations
{
    public partial class categoryiedv21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantServiceId",
                table: "RestaurantCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantServiceId",
                table: "RestaurantCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
