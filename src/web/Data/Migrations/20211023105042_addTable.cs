using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenditureCategoryId",
                table: "Expenditures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenditureCategories",
                columns: table => new
                {
                    ExpenditureCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenditureId = table.Column<int>(type: "int", nullable: false),
                    IsShowUp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureCategories", x => x.ExpenditureCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenditures_ExpenditureCategoryId",
                table: "Expenditures",
                column: "ExpenditureCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditures_ExpenditureCategories_ExpenditureCategoryId",
                table: "Expenditures",
                column: "ExpenditureCategoryId",
                principalTable: "ExpenditureCategories",
                principalColumn: "ExpenditureCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenditures_ExpenditureCategories_ExpenditureCategoryId",
                table: "Expenditures");

            migrationBuilder.DropTable(
                name: "ExpenditureCategories");

            migrationBuilder.DropIndex(
                name: "IX_Expenditures_ExpenditureCategoryId",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "ExpenditureCategoryId",
                table: "Expenditures");
        }
    }
}
