﻿// <auto-generated />
using System;
using GamingUniversityApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamingUniversityApp.Data.Migrations
{
    [DbContext(typeof(GamingUniversityAppDbContext))]
    [Migration("20241030215822_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of the course that the assignment belongs to");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Description of the assignment");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasComment("Due date for this assignment");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the assignment");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the course");

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasComment("Amount of credits given to students for completing the course");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Course description");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Email address of the student");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("First name of the student");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Last name of the student");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.StudentCourse", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of the course");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of the student");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier");

                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of the assignment");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Content of the submission");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Grade for the submission");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique identifier of the student");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of the submission");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Assignment", b =>
                {
                    b.HasOne("GamingUniversityApp.Data.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.StudentCourse", b =>
                {
                    b.HasOne("GamingUniversityApp.Data.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingUniversityApp.Data.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Submission", b =>
                {
                    b.HasOne("GamingUniversityApp.Data.Models.Assignment", "Assignment")
                        .WithMany("Submissions")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingUniversityApp.Data.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Assignment", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("GamingUniversityApp.Data.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
