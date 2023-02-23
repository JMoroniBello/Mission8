using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission8.Migrations
{
    public partial class Initial : Migration
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
                    Task = table.Column<string>(nullable: true),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskId);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
