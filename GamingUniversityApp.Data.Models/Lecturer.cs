namespace GamingUniversityApp.Data.Models
{
	public class Lecturer
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string WorkPhoneNumber { get; set; } = null!;
		public virtual ApplicationUser User { get; set; } = null!;
		public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
	}
}
