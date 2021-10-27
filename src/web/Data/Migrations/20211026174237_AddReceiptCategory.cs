using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class AddReceiptCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReceiptCategories",
                columns: table => new
                {
                    ReceiptCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenditureId = table.Column<int>(type: "int", nullable: false),
                    IsShowUp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptCategories", x => x.ReceiptCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                column: "ReceiptCategoriesReceiptCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts",
                column: "ReceiptCategoriesReceiptCategoryId",
                principalTable: "ReceiptCategories",
                principalColumn: "ReceiptCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptCategories_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "ReceiptCategories");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ReceiptCategoriesReceiptCategoryId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ReceiptCategoriesReceiptCategoryId",
                table: "Receipts");
        }
    }
}
