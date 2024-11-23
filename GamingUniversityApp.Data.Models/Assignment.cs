namespace GamingUniversityApp.Data.Models
{
	public class Assignment
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public DateTime DueDate { get; set; }
		public Guid CourseId { get; set; }
		public bool IsDeleted { get; set; }
		public virtual Course Course { get; set; } = null!;
		public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
	}
}