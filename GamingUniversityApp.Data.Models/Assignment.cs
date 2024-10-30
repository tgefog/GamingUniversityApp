namespace GamingUniversityApp.Data.Models
{
	public class Assignment
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public DateTime DueDate { get; set; }
		public Guid CourseId { get; set; }
		public Course Course { get; set; } = null!;
		public ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
	}
}