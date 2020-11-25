using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMealPlanner.Migrations
{
    public partial class AddMealPlanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealList",
                table: "MealList");

            migrationBuilder.RenameTable(
                name: "MealList",
                newName: "MealRepo");

            migrationBuilder.AlterColumn<string>(
                name: "MealType",
                table: "MealRepo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MealName",
                table: "MealRepo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "MealRepo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cuisine",
                table: "MealRepo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealRepo",
                table: "MealRepo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MealTimes",
                columns: table => new
                {
                    MealTimeId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(nullable: false),
                    Time = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTimes", x => x.MealTimeId);
                });

            migrationBuilder.CreateTable(
                name: "MealPlan",
                columns: table => new
                {
                    MealTimeId = table.Column<long>(nullable: false),
                    MealId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlan", x => new { x.MealId, x.MealTimeId });
                    table.ForeignKey(
                        name: "FK_MealPlan_MealRepo_MealId",
                        column: x => x.MealId,
                        principalTable: "MealRepo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealPlan_MealTimes_MealTimeId",
                        column: x => x.MealTimeId,
                        principalTable: "MealTimes",
                        principalColumn: "MealTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlan_MealTimeId",
                table: "MealPlan",
                column: "MealTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlan");

            migrationBuilder.DropTable(
                name: "MealTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealRepo",
                table: "MealRepo");

            migrationBuilder.RenameTable(
                name: "MealRepo",
                newName: "MealList");

            migrationBuilder.AlterColumn<string>(
                name: "MealType",
                table: "MealList",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MealName",
                table: "MealList",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "MealList",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cuisine",
                table: "MealList",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealList",
                table: "MealList",
                column: "Id");
        }
    }
}
