namespace GamingUniversityApp.Data.Models
{
	public class Student
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
		public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
	}
}