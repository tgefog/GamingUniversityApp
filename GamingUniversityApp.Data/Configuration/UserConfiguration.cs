namespace GamingUniversityApp.Data.Configuration
{
    using GamingUniversityApp.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedData());
        }
        private List<ApplicationUser> SeedData()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var lecturer1 = new ApplicationUser()
            {
                Id = Guid.Parse("658c530c-6d7e-4bc5-956d-571166b579e3"),
                UserName = "Lecturer",
                FirstName = "Lecturer",
                LastName = "Lecturer",
                NormalizedUserName = "LECTURER",
                Email = "lecturer1@abv.bg",
                NormalizedEmail = "LECTURER1@ABV.BG",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var lecturer2 = new ApplicationUser()
            {
                Id = Guid.Parse("1ee14426-147e-4d41-ad56-4c1388086c8a"),
                UserName = "Lecturer2",
                FirstName = "Lecturer2",
                LastName = "Lecturer2",
                NormalizedUserName = "LECTURER2",
                Email = "lecturer2@abv.bg",
                NormalizedEmail = "LECTURER2@ABV.BG",
                PhoneNumber = "98765",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var student1 = new ApplicationUser()
            {
                Id = Guid.Parse("25f228f7-d8d5-4a23-93fb-8b489ce206a1"),
                UserName = "Student1",
                FirstName = "Student1",
                LastName = "Student1",
                NormalizedUserName = "STUDENT1",
                Email = "student1@abv.bg",
                NormalizedEmail = "STUDENT1@ABV.BG",
                PhoneNumber = "12345",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var student2 = new ApplicationUser()
            {
                Id = Guid.Parse("284bd583-dd2c-4453-98fa-74236f9cdcf9"),
                UserName = "Student2",
                FirstName = "Student2",
                LastName = "Student2",
                NormalizedUserName = "STUDENT2",
                Email = "student2@abv.bg",
                NormalizedEmail = "STUDENT2@ABV.BG",
                PhoneNumber = "13345",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var student3 = new ApplicationUser()
            {
                Id = Guid.Parse("79cda038-04b2-4333-a6b5-8fff05f5df8c"),
                UserName = "Student3",
                FirstName = "Student3",
                LastName = "Student3",
                NormalizedUserName = "STUDENT3",
                Email = "student3@abv.bg",
                NormalizedEmail = "STUDENT3@ABV.BG",
                PhoneNumber = "12245",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            lecturer1.PasswordHash = hasher.HashPassword(lecturer1, "lecturer1234");
            lecturer2.PasswordHash = hasher.HashPassword(lecturer2, "lecturer1234");
            student1.PasswordHash = hasher.HashPassword(student1, "student1234");
            student2.PasswordHash = hasher.HashPassword(student2, "student1234");
            student3.PasswordHash = hasher.HashPassword(student3, "student1234");
            return new List<ApplicationUser>() { lecturer1, lecturer2, student1, student2, student3 };
        }
    }
}
