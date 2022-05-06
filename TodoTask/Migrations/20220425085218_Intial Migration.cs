using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoTask.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoWorks",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoWorks", x => x.TodoId);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodoWorkTodoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_TodoLists_TodoWorks_TodoWorkTodoId",
                        column: x => x.TodoWorkTodoId,
                        principalTable: "TodoWorks",
                        principalColumn: "TodoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_TodoWorkTodoId",
                table: "TodoLists",
                column: "TodoWorkTodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "TodoWorks");
        }
    }
}
