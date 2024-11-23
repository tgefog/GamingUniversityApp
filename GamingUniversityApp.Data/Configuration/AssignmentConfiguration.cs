﻿namespace GamingUniversityApp.Data.Configuration
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
        }
    }
}