using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingUniversityApp.Data.Configuration
{
	public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
	{
		public void Configure(EntityTypeBuilder<Submission> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.IsRequired()
				.HasComment("Unique identifier");

			builder.Property(e => e.AssignmentId)
				.IsRequired()
				.HasComment("Unique identifier of the assignment");

			builder.HasOne(e => e.Assignment)
				.WithMany(a => a.Submissions)
				.HasForeignKey(e => e.AssignmentId)
				.IsRequired();

			builder.Property(e => e.StudentId)
				.IsRequired()
				.HasComment("Unique identifier of the student");

			builder.HasOne(e => e.Student)
				.WithMany()
				.HasForeignKey(e => e.StudentId)
				.IsRequired();

			builder.Property(e => e.Content)
				.IsRequired()
				.HasComment("Content of the submission");

			builder.Property(e => e.SubmissionDate)
				.IsRequired()
				.HasComment("Date of the submission");

			builder.Property(e => e.Grade)
				.IsRequired()
				.HasComment("Grade for the submission");
		}
	}
}
