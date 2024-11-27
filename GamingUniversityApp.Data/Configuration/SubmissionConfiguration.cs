using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingUniversityApp.Data.Configuration
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .HasComment("Unique identifier");

            builder.Property(s => s.AssignmentId)
                .IsRequired()
                .HasComment("Unique identifier of the assignment");

            builder.HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(s => s.StudentId)
                .IsRequired()
                .HasComment("Unique identifier of the student");

            builder.HasOne(s => s.Student)
                .WithMany(st => st.Submissions)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(s => s.Content)
                .IsRequired()
                .HasComment("Content of the submission");

            builder.Property(s => s.SubmissionDate)
                .IsRequired()
                .HasComment("Date of the submission");

            builder.Property(s => s.Grade)
                .IsRequired()
                .HasComment("Grade for the submission");

            builder.HasData(this.SeedSubmissions());
        }
        private List<Submission> SeedSubmissions()
        {
            return new List<Submission>
            {
                new Submission
                {
                    Id = Guid.Parse("CFF8BA3E-3F3C-4C4D-9883-57F819E23509"),
                    AssignmentId = Guid.Parse("AF6D1A97-74C4-4C9F-BEFE-8F6DBB45269F"), // League Mechanics
                    StudentId = Guid.Parse("9250c8b9-66e5-4a04-b26d-a02203cd0ca2"), // Example Student
                    SubmissionDate = DateTime.UtcNow.AddDays(-1),
                    Content = "Completed the map awareness module.",
                    Grade = "A"
                },
                new Submission
                {
                    Id = Guid.Parse("12AA74F9-2589-496D-99C9-7746F32EDE7E"),
                    AssignmentId = Guid.Parse("4DA79F7F-BB60-4D24-8992-1B2ED252F64F"), // Counter-Strike Tactics
                    StudentId = Guid.Parse("56d668ca-324c-4e54-90d2-800fa38d932a"), // Example Student
                    SubmissionDate = DateTime.UtcNow,
                    Content = "Submitted the team strategy report.",
                    Grade = "B+"
                }
            };
        }
    }
}
