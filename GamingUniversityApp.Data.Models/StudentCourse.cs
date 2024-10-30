using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingUniversityApp.Data.Models
{
	public class StudentCourse
	{
		[Comment("Unique identifier of the student")]
		public Guid StudentId { get; set; }
		[ForeignKey(nameof(StudentId))]
		public Student Student { get; set; } = null!;
		[Comment("Unique identifier of the course")]
		public Guid CourseId { get; set; }
		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;
		public bool IsDeleted { get; set; }
	}
}
