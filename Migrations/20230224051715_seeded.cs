using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission8.Migrations
{
    public partial class seeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<byte>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (byte)1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (byte)2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (byte)3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (byte)4, "Church" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, (byte)1, false, "Today", (byte)1, "Eat" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 2, (byte)2, true, "Today", (byte)1, "Eat" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 3, (byte)3, false, "Today", (byte)1, "Eat" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 4, (byte)4, true, "Today", (byte)1, "Eat" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
