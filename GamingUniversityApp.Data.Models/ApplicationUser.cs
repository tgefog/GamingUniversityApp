namespace GamingUniversityApp.Data.Models
{
	public class ApplicationUser //: IdentityUser
    {
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public ICollection<StudentCourse> CourseEnrollments { get; set; }
	}
}
