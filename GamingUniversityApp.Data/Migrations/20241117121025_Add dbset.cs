using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingUniversityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adddbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturer_LecturerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_AspNetUsers_UserId",
                table: "Lecturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer");

            migrationBuilder.RenameTable(
                name: "Lecturer",
                newName: "Lecturers");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturer_UserId",
                table: "Lecturers",
                newName: "IX_Lecturers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_AspNetUsers_UserId",
                table: "Lecturers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_AspNetUsers_UserId",
                table: "Lecturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers");

            migrationBuilder.RenameTable(
                name: "Lecturers",
                newName: "Lecturer");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_UserId",
                table: "Lecturer",
                newName: "IX_Lecturer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturer_LecturerId",
                table: "Courses",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_AspNetUsers_UserId",
                table: "Lecturer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
