using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingUniversityApp.Data.Configuration
{
	public class ApplicationUserCourseConfiguration : IEntityTypeConfiguration<ApplicationUserCourse>
	{
		public void Configure(EntityTypeBuilder<ApplicationUserCourse> builder)
		{
			builder
				.HasKey(uc => new { uc.ApplicationUserId, uc.CourseId });

			builder
				.HasOne(uc => uc.Course)
				.WithMany(c => c.CourseApplicationUsers)
				.HasForeignKey(uc => uc.CourseId);

			builder.HasOne(uc => uc.ApplicationUser)
				.WithMany(u => u.ApplicationUserCourses)
				.HasForeignKey(uc => uc.ApplicationUserId);
		}
	}
}
