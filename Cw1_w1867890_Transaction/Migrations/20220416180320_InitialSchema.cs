using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw1_w1867890_Transaction.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionCategoryId = table.Column<int>(type: "int", nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    TransactionRecurring = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
