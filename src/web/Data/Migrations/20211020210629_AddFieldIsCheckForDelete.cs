using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Data.Migrations
{
    public partial class AddFieldIsCheckForDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckForDelete",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckForDelete",
                table: "Categories");
        }
    }
}
