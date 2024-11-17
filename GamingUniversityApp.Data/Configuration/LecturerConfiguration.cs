namespace GamingUniversityApp.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;

	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;
	using static GamingUniversityApp.Common.EntityValidationConstants.Lecturer;
	public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
	{
		public void Configure(EntityTypeBuilder<Lecturer> builder)
		{
			builder
				.HasKey(l => l.Id);

			builder
				.Property(l => l.WorkPhoneNumber)
				.IsRequired()
				.HasMaxLength(PhoneNumberMaxLength);

			builder
				.Property(l => l.UserId)
				.IsRequired();
			builder
				.HasOne(l => l.User)
				.WithOne()
				.HasForeignKey<Lecturer>(l => l.UserId);

			builder
				.HasMany(l => l.Courses)
				.WithOne(c => c.Lecturer)
				.HasForeignKey(c => c.LecturerId)
				.IsRequired();
		}
	}
}
