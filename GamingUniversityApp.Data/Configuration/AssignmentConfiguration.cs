namespace GamingUniversityApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
           .IsRequired()
           .HasComment("Unique identifier");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength)
                .HasComment("Name of the assignment");

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength)
                .HasComment("Description of the assignment");

            builder.Property(a => a.DueDate)
                .IsRequired()
                .HasComment("Due date for this assignment");

            builder.Property(a => a.CourseId)
                .IsRequired()
                .HasComment("Unique identifier of the course that the assignment belongs to");

            builder.Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasData(this.SeedAssignments());
        }
        private List<Assignment> SeedAssignments()
        {
            return new List<Assignment>
            {
                new Assignment
                {
                    Id = Guid.Parse("AF6D1A97-74C4-4C9F-BEFE-8F6DBB45269F"),
                    Name = "Introduction to League Mechanics",
                    Description = "Learn the basics of lane control, farming, and map awareness in League of Legends.",
                    DueDate = DateTime.UtcNow.AddDays(14),
                    CourseId = Guid.Parse("A3841C0B-3660-4398-93F5-F606E7D5BF60")
                },
                new Assignment
                {
                    Id = Guid.Parse("4DA79F7F-BB60-4D24-8992-1B2ED252F64F"),
                    Name = "Counter-Strike Tactics",
                    Description = "Understand team strategies and map control in Counter-Strike.",
                    DueDate = DateTime.UtcNow.AddDays(21),
                    CourseId = Guid.Parse("61088DAB-2CA0-4258-B7FA-5737CE436FF2")
                }
            };
        }

    }
}