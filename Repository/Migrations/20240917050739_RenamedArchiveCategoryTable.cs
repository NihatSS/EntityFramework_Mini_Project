using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class RenamedArchiveCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Archives",
                table: "Archives");

            migrationBuilder.RenameTable(
                name: "Archives",
                newName: "ArchiveCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchiveCategories",
                table: "ArchiveCategories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchiveCategories",
                table: "ArchiveCategories");

            migrationBuilder.RenameTable(
                name: "ArchiveCategories",
                newName: "Archives");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Archives",
                table: "Archives",
                column: "Id");
        }
    }
}
