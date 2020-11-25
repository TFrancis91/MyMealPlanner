using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMealPlanner.Migrations
{
    public partial class AddQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ServingSize",
                table: "MealRepo",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "MealRepo");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ingredients");
        }
    }
}
