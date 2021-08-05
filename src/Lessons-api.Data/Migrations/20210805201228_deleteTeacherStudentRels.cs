using Microsoft.EntityFrameworkCore.Migrations;

namespace Lessons_api.Data.Migrations
{
    public partial class deleteTeacherStudentRels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherStudentRels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherStudentRels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudentRels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherStudentRels_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherStudentRels_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudentRels_StudentId",
                table: "TeacherStudentRels",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudentRels_TeacherId",
                table: "TeacherStudentRels",
                column: "TeacherId");
        }
    }
}
