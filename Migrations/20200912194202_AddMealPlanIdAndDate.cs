using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMealPlanner.Migrations
{
    public partial class AddMealPlanIdAndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MealPlanId",
                table: "MealPlan",
                nullable: false,
                defaultValue: 0L)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "MealPlan",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_MealTimeId",
                table: "MealPlan",
                column: "MealTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_MealId",
                table: "MealPlan",
                column: "MealId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_MealId",
                table: "MealPlan",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan");

            migrationBuilder.DropIndex(
                name: "IX_MealPlan_MealId",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "MealPlan");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MealPlan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlan",
                table: "MealPlan",
                columns: new[] { "MealId", "MealTimeId" });
        }
    }
}
