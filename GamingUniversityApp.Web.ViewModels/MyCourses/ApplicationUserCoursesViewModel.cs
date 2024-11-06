namespace GamingUniversityApp.Web.ViewModels.MyCourses
{
	public class ApplicationUserCoursesViewModel
	{
		public string CourseId { get; set; } = null!;
		public string CourseName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int Credits { get; set; }
		public string ImageUrl { get; set; } = null!;

	}
}
