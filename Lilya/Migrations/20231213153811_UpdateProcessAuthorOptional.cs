using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lilya.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProcessAuthorOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Authors_AuthorId",
                table: "Processes");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Processes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Authors_AuthorId",
                table: "Processes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Authors_AuthorId",
                table: "Processes");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Processes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Authors_AuthorId",
                table: "Processes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
