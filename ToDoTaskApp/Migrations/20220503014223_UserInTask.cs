using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoTaskApp.Migrations
{
    public partial class UserInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategories_Users_UserId",
                table: "TaskCategories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategories_Users_UserId",
                table: "TaskCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskCategories_Users_UserId",
                table: "TaskCategories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskCategories_Users_UserId",
                table: "TaskCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
