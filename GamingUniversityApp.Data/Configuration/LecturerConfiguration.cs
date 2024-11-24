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

            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(l => l.Courses)
                .WithOne(c => c.Lecturer)
                .HasForeignKey(c => c.LecturerId);

            builder.HasData(this.GenerateLecturers());
        }
        private IEnumerable<Lecturer> GenerateLecturers()
        {
            IEnumerable<Lecturer> lecturers = new List<Lecturer>()
            {
                new Lecturer()
                {
                    Id = Guid.Parse("cc5a700b-076e-4c88-b8ad-5ebe548735a0"),
                    UserId = Guid.Parse("658c530c-6d7e-4bc5-956d-571166b579e3"),
                    WorkPhoneNumber = "12345678",
                    Department = "FPS"

                },
                new Lecturer()
                {
                    Id = Guid.Parse("eb9a19de-0b05-48f5-9c2f-dbab7ed332b6"),
                    UserId = Guid.Parse("1ee14426-147e-4d41-ad56-4c1388086c8a"),
                    WorkPhoneNumber = "87654321",
                    Department = "Moba"
                }
            };
            return lecturers;
        }
    }
}
