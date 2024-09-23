using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryEntitty_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEntitty",
                table: "CategoryEntitty");

            migrationBuilder.RenameTable(
                name: "CategoryEntitty",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoryEntitty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEntitty",
                table: "CategoryEntitty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryEntitty_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "CategoryEntitty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
