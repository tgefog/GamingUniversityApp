using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingUniversityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAppUserCourseDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_Courses_CourseId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCourse",
                table: "ApplicationUserCourse");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCourse",
                newName: "UsersCourses");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserCourse_CourseId",
                table: "UsersCourses",
                newName: "IX_UsersCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCourses",
                table: "UsersCourses",
                columns: new[] { "ApplicationUserId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCourses_AspNetUsers_ApplicationUserId",
                table: "UsersCourses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCourses_Courses_CourseId",
                table: "UsersCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCourses_AspNetUsers_ApplicationUserId",
                table: "UsersCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCourses_Courses_CourseId",
                table: "UsersCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCourses",
                table: "UsersCourses");

            migrationBuilder.RenameTable(
                name: "UsersCourses",
                newName: "ApplicationUserCourse");

            migrationBuilder.RenameIndex(
                name: "IX_UsersCourses_CourseId",
                table: "ApplicationUserCourse",
                newName: "IX_ApplicationUserCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCourse",
                table: "ApplicationUserCourse",
                columns: new[] { "ApplicationUserId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserCourse",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_Courses_CourseId",
                table: "ApplicationUserCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
