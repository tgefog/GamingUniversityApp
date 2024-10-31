using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingUniversityApp.Data.Configuration
{
	public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
	{
		public void Configure(EntityTypeBuilder<StudentCourse> builder)
		{
			builder.HasKey(ce => new { ce.CourseId, ce.StudentId });
			builder.HasOne(ce => ce.Course)
			.WithMany(c => c.CourseStudents)
			.HasForeignKey(ce => ce.CourseId)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(ce => ce.Student)
			.WithMany(s => s.StudentCourses)
			.HasForeignKey(ce => ce.StudentId)
			.OnDelete(DeleteBehavior.Restrict);
		}
	}
}