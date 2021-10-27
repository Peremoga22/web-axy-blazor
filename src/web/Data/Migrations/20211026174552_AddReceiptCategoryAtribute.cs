using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class AddReceiptCategoryAtribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                newName: "ReceiptCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                newName: "IX_Receipts_ReceiptCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoryId",
                table: "Receipts",
                column: "ReceiptCategoryId",
                principalTable: "ReceiptCategories",
                principalColumn: "ReceiptCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoryId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "ReceiptCategoryId",
                table: "Receipts",
                newName: "ReceiptCategoriesReceiptCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ReceiptCategoryId",
                table: "Receipts",
                newName: "IX_Receipts_ReceiptCategoriesReceiptCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                column: "ReceiptCategoriesReceiptCategoryId",
                principalTable: "ReceiptCategories",
                principalColumn: "ReceiptCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
