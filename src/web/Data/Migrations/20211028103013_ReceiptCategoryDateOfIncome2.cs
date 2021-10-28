using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class ReceiptCategoryDateOfIncome2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfPurchase",
                table: "ReceiptCategories",
                newName: "DateOfIncome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfIncome",
                table: "ReceiptCategories",
                newName: "DateOfPurchase");
        }
    }
}
