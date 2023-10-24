using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFLAB.Migrations
{
    /// <inheritdoc />
    public partial class AuthorsPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Posts");
        }
    }
}
