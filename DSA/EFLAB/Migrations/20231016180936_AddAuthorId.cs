using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFLAB.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorId1",
                table: "Posts",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "AuthorID");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
