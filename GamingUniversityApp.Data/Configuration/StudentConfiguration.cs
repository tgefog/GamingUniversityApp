using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingUniversityApp.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .HasComment("Unique identifier");

            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateStudents());
        }
        private IEnumerable<Student> GenerateStudents()
        {
            IEnumerable<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = Guid.Parse("9250c8b9-66e5-4a04-b26d-a02203cd0ca2"),
                    UserId = Guid.Parse("25f228f7-d8d5-4a23-93fb-8b489ce206a1"),

                },
                new Student()
                {
                    Id = Guid.Parse("56d668ca-324c-4e54-90d2-800fa38d932a"),
                    UserId = Guid.Parse("284bd583-dd2c-4453-98fa-74236f9cdcf9"),
                },
                new Student()
                {
                    Id = Guid.Parse("fbceacec-0bf1-48eb-a473-f7f7c4f17e4b"),
                    UserId = Guid.Parse("79cda038-04b2-4333-a6b5-8fff05f5df8c"),
                }
            };
            return students;
        }
    }
}
