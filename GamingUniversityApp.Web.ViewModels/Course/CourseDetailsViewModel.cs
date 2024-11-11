namespace GamingUniversityApp.Web.ViewModels.Course
{
	using Data.Models;
	using Services.Mapping;
	
	public class CourseDetailsViewModel : IMapFrom<Course>
	{
		public string Description { get; set; } = null!;
		public string CourseName { get; set; } = null!;
		public int Credits { get; set; }
		public string ImageUrl { get; set; } = null!;

	}
}
