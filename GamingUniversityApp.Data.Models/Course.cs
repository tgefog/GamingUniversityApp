namespace GamingUniversityApp.Data.Models
{
	public class Course
	{

		public Guid Id { get; set; } = Guid.NewGuid();
		public string CourseName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int Credits { get; set; }
		//[Required]
		//[Comment("Lecturer that is assigned to the course")]
		//public Lecturer Lecturer { get; set; }
		public ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();
		public ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
	}
}