using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamingUniversityApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CourseAssignmentSubmissionSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the course"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Course description"),
                    Credits = table.Column<int>(type: "int", nullable: false, comment: "Amount of credits given to students for completing the course"),
                    LecturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true, defaultValue: "/images/No_Image_Available.jpg"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Lecturers_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the assignment"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Description of the assignment"),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Due date for this assignment"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of the course that the assignment belongs to"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of the student"),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of the course"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier"),
                    AssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of the assignment"),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier of the student"),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the submission"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Content of the submission"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Grade for the submission")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Submissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1ee14426-147e-4d41-ad56-4c1388086c8a"), 0, "ae033818-87ef-40c0-a69d-075bb3957e86", "lecturer2@abv.bg", true, "Lecturer2", "Lecturer2", false, null, "LECTURER2@ABV.BG", "LECTURER2", "AQAAAAIAAYagAAAAEHqYZbEkYjHE6AjFErxZ+o7fIlNKFY6qKWQ6gbUnmwVVkoHI4fmoP4fa2Pri8DjTSA==", "98765", false, "290de3c5-5407-4fea-9f6f-99dd4800f36c", false, "Lecturer2" },
                    { new Guid("25f228f7-d8d5-4a23-93fb-8b489ce206a1"), 0, "05a6e8f7-f59f-41ea-a370-069be1ac07e1", "student1@abv.bg", true, "Student1", "Student1", false, null, "STUDENT1@ABV.BG", "STUDENT1", "AQAAAAIAAYagAAAAEIHpSxpMSdDR3G8wYrqzbe/tzuil+FxFKc1NwjtphwYWPzW8fvCg6vc/RRsOsFawQA==", "12345", false, "edf61d1b-755c-4a5f-88ab-1092446f9888", false, "Student1" },
                    { new Guid("284bd583-dd2c-4453-98fa-74236f9cdcf9"), 0, "f90b954f-1916-41ff-91cf-9155a540feca", "student2@abv.bg", true, "Student2", "Student2", false, null, "STUDENT2@ABV.BG", "STUDENT2", "AQAAAAIAAYagAAAAEAcg8g8oz7zt9vRIw2E6RBn8f4+N52udtCt6vATwlQOnFJ3TJymdBPBnH7VEUkywww==", "13345", false, "efc14b1e-dbcb-4d41-8b67-f2a53629bf69", false, "Student2" },
                    { new Guid("658c530c-6d7e-4bc5-956d-571166b579e3"), 0, "3a97d908-b7d5-432f-a58d-c16871cb3a6a", "lecturer1@abv.bg", true, "Lecturer", "Lecturer", false, null, "LECTURER1@ABV.BG", "LECTURER", "AQAAAAIAAYagAAAAENgcMSzNqVLi08qQNzBA3w0JD2yESuC5Tb9JBJbG/rambGP/h6eAJVFGr2pgf8oDcw==", "1234567890", false, "a0aeefeb-a9e9-4ee5-bcae-4ae25ee6c28b", false, "Lecturer" },
                    { new Guid("79cda038-04b2-4333-a6b5-8fff05f5df8c"), 0, "a7600aec-24ea-4027-ae1d-065dfd95ef61", "student3@abv.bg", true, "Student3", "Student3", false, null, "STUDENT3@ABV.BG", "STUDENT3", "AQAAAAIAAYagAAAAEBNU91Z6wBSEjhGTu+k2zhuoYR26CmnxZbTiWJuofjg95r7/PvGpEAL0Ru2d71FY/Q==", "12245", false, "23255884-a37b-4166-ab7f-116213ed5d56", false, "Student3" }
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "Department", "UserId", "WorkPhoneNumber" },
                values: new object[,]
                {
                    { new Guid("cc5a700b-076e-4c88-b8ad-5ebe548735a0"), "FPS", new Guid("658c530c-6d7e-4bc5-956d-571166b579e3"), "12345678" },
                    { new Guid("eb9a19de-0b05-48f5-9c2f-dbab7ed332b6"), "Moba", new Guid("1ee14426-147e-4d41-ad56-4c1388086c8a"), "87654321" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("56d668ca-324c-4e54-90d2-800fa38d932a"), new Guid("284bd583-dd2c-4453-98fa-74236f9cdcf9") },
                    { new Guid("9250c8b9-66e5-4a04-b26d-a02203cd0ca2"), new Guid("25f228f7-d8d5-4a23-93fb-8b489ce206a1") },
                    { new Guid("fbceacec-0bf1-48eb-a473-f7f7c4f17e4b"), new Guid("79cda038-04b2-4333-a6b5-8fff05f5df8c") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Credits", "Description", "LecturerId" },
                values: new object[,]
                {
                    { new Guid("61088dab-2ca0-4258-b7fa-5737ce436ff2"), "Counter Strike", 30, "Counter-Strike is an objective-based, multiplayer tactical first-person shooter. Two opposing teams—the Terrorists and the Counter Terrorists—compete in game modes to complete objectives, such as securing a location to plant or defuse a bomb and rescuing or guarding hostages. At the end of each round, players are rewarded based on their individual performance with in-game currency to spend on more powerful weapons in subsequent rounds. Winning rounds results in more money than losing and completing objectives such as killing enemy players gives cash bonuses.Uncooperative actions, such as killing teammates, result in a penalty.", new Guid("cc5a700b-076e-4c88-b8ad-5ebe548735a0") },
                    { new Guid("a3841c0b-3660-4398-93f5-f606e7d5bf60"), "League of Legends", 25, "League of Legends is a multiplayer online battle arena (MOBA) game in which the player controls a character (\"champion\") with a set of unique abilities from an isometric perspective. As of 2024, there are 168 champions available to play. Over the course of a match, champions gain levels by accruing experience points (XP) through killing enemies. Items can be acquired to increase champions' strength, and are bought with gold, which players accrue passively over time and earn actively by defeating the opposing team's minions, champions, or defensive structures. In the main game mode, Summoner's Rift, items are purchased through a shop menu available to players only when their champion is in the team's base. Each match is discrete; levels and items do not transfer from one match to another.", new Guid("eb9a19de-0b05-48f5-9c2f-dbab7ed332b6") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "CourseId", "Description", "DueDate", "Name" },
                values: new object[,]
                {
                    { new Guid("4da79f7f-bb60-4d24-8992-1b2ed252f64f"), new Guid("61088dab-2ca0-4258-b7fa-5737ce436ff2"), "Understand team strategies and map control in Counter-Strike.", new DateTime(2024, 12, 18, 17, 27, 6, 203, DateTimeKind.Utc).AddTicks(4189), "Counter-Strike Tactics" },
                    { new Guid("af6d1a97-74c4-4c9f-befe-8f6dbb45269f"), new Guid("a3841c0b-3660-4398-93f5-f606e7d5bf60"), "Learn the basics of lane control, farming, and map awareness in League of Legends.", new DateTime(2024, 12, 11, 17, 27, 6, 203, DateTimeKind.Utc).AddTicks(4174), "Introduction to League Mechanics" }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "AssignmentId", "Content", "Grade", "StudentId", "SubmissionDate" },
                values: new object[,]
                {
                    { new Guid("12aa74f9-2589-496d-99c9-7746f32ede7e"), new Guid("4da79f7f-bb60-4d24-8992-1b2ed252f64f"), "Submitted the team strategy report.", "B+", new Guid("56d668ca-324c-4e54-90d2-800fa38d932a"), new DateTime(2024, 11, 27, 17, 27, 6, 205, DateTimeKind.Utc).AddTicks(9451) },
                    { new Guid("cff8ba3e-3f3c-4c4d-9883-57f819e23509"), new Guid("af6d1a97-74c4-4c9f-befe-8f6dbb45269f"), "Completed the map awareness module.", "A", new Guid("9250c8b9-66e5-4a04-b26d-a02203cd0ca2"), new DateTime(2024, 11, 26, 17, 27, 6, 205, DateTimeKind.Utc).AddTicks(9440) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_UserId",
                table: "Lecturers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssignmentId",
                table: "Submissions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentId",
                table: "Submissions",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
