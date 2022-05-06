using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoTask.Migrations
{
    public partial class Todo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoLists_TodoWorks_TodoWorkTodoId",
                table: "TodoLists");

            migrationBuilder.DropIndex(
                name: "IX_TodoLists_TodoWorkTodoId",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "TodoWorkTodoId",
                table: "TodoLists");

            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "TodoWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TodoListListId",
                table: "TodoWorks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoWorks_TodoListListId",
                table: "TodoWorks",
                column: "TodoListListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoWorks_TodoLists_TodoListListId",
                table: "TodoWorks",
                column: "TodoListListId",
                principalTable: "TodoLists",
                principalColumn: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoWorks_TodoLists_TodoListListId",
                table: "TodoWorks");

            migrationBuilder.DropIndex(
                name: "IX_TodoWorks_TodoListListId",
                table: "TodoWorks");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "TodoWorks");

            migrationBuilder.DropColumn(
                name: "TodoListListId",
                table: "TodoWorks");

            migrationBuilder.AddColumn<int>(
                name: "TodoWorkTodoId",
                table: "TodoLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_TodoWorkTodoId",
                table: "TodoLists",
                column: "TodoWorkTodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoLists_TodoWorks_TodoWorkTodoId",
                table: "TodoLists",
                column: "TodoWorkTodoId",
                principalTable: "TodoWorks",
                principalColumn: "TodoId");
        }
    }
}
