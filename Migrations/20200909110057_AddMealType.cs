using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMealPlanner.Migrations
{
    public partial class AddMealType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "MealList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealType",
                table: "MealList");
        }
    }
}
