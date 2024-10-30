using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static GamingUniversityApp.Common.EntityValidationConstants.Student;

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

			builder.Property(s => s.FirstName)
				.IsRequired()
				.HasMaxLength(FirstNameMaxLength)
				.HasComment("First name of the student");

			builder.Property(s => s.LastName)
				.IsRequired()
				.HasMaxLength(LastNameMaxLength)
				.HasComment("Last name of the student");

			builder.Property(s => s.Email)
				.IsRequired()
				.HasMaxLength(EmailMaxLength)
				.HasComment("Email address of the student");

			//builder.HasData(this.GenerateStudents());
		}
		//private IEnumerable<Student> GenerateStudents()
		//{
		//	IEnumerable<Student> students = new List<Student>()
		//	{
		//		new Student()
		//		{
		//			FirstName = "Ivan",
		//			LastName = "Ivanov",
		//			Email = "ivanivanov@gmail.com"

		//		},
		//		new Student()
		//		{
		//			FirstName = "Petar",
		//			LastName = "Petrov",
		//			Email = "PPetrov@hotmail.com"
		//		},
		//		new Student()
		//		{
		//			FirstName = "Vasil",
		//			LastName = "Iliev",
		//			Email = "VIS2@hotmail.com"
		//		},
		//		new Student()
		//		{
		//			FirstName = "Georgi",
		//			LastName = "Iliev",
		//			Email = "VIS2@gmail.com"
		//		}
		//	};
		//	return students;
		//}
	}
}
