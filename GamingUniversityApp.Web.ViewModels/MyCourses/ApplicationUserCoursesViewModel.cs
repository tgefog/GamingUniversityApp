namespace GamingUniversityApp.Web.ViewModels.MyCourses
{
    using AutoMapper;
    using Data.Models;
	using Services.Mapping;
	public class ApplicationUserCoursesViewModel :IMapFrom<StudentCourse>, IHaveCustomMappings
	{
		public string CourseId { get; set; } = null!;
		public string CourseName { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int Credits { get; set; }
		public string? ImageUrl { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<StudentCourse, ApplicationUserCoursesViewModel>()
                .ForMember(d => d.CourseId, x => x.MapFrom(s => s.CourseId.ToString()))
                .ForMember(d => d.CourseName, x => x.MapFrom(s => s.Course.CourseName))
                .ForMember(d => d.Description, x => x.MapFrom(s => s.Course.Description))
                .ForMember(d => d.Credits, x => x.MapFrom(s => s.Course.Credits))
                .ForMember(d => d.ImageUrl, x => x.MapFrom(s => s.Course.ImageUrl));
        }
    }
}
