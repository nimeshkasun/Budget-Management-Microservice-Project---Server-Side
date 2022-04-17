using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw1_w1867890_Category.Migrations
{
    public partial class renameCategoryColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryBudget",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Categories",
                newName: "CatType");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CatName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CatId");

            migrationBuilder.AddColumn<double>(
                name: "CatBudget",
                table: "Categories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatBudget",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CatType",
                table: "Categories",
                newName: "CategoryType");

            migrationBuilder.RenameColumn(
                name: "CatName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<double>(
                name: "CategoryBudget",
                table: "Categories",
                type: "float",
                maxLength: 20,
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
