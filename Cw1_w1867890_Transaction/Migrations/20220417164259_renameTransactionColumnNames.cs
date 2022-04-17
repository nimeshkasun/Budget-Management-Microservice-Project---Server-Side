using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw1_w1867890_Transaction.Migrations
{
    public partial class renameTransactionColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionRecurring",
                table: "Transactions",
                newName: "TranRecurring");

            migrationBuilder.RenameColumn(
                name: "TransactionDescription",
                table: "Transactions",
                newName: "TranDescription");

            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "TranDate");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryId",
                table: "Transactions",
                newName: "TranCatId");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "TranId");

            migrationBuilder.AddColumn<double>(
                name: "TranAmount",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TranAmount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TranRecurring",
                table: "Transactions",
                newName: "TransactionRecurring");

            migrationBuilder.RenameColumn(
                name: "TranDescription",
                table: "Transactions",
                newName: "TransactionDescription");

            migrationBuilder.RenameColumn(
                name: "TranDate",
                table: "Transactions",
                newName: "TransactionDate");

            migrationBuilder.RenameColumn(
                name: "TranCatId",
                table: "Transactions",
                newName: "TransactionCategoryId");

            migrationBuilder.RenameColumn(
                name: "TranId",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.AddColumn<double>(
                name: "TransactionAmount",
                table: "Transactions",
                type: "float",
                maxLength: 10,
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
