using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFLAB.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorPropToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID");
        }
    }
}
