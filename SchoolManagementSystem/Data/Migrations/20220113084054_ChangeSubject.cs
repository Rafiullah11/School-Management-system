using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class ChangeSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false),
                    SectionName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentModel");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
