namespace GamingUniversityApp.Web.ViewModels.Course
{
    using Data.Models;
    using GamingUniversityApp.Services.Mapping;
    public class CourseIndexViewModel : IMapFrom<Course>
    {
        public string Id { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Credits { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}