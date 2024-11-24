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
        }
    }
}
