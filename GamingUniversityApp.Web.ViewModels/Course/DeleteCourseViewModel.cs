namespace GamingUniversityApp.Web.ViewModels.Course
{
    using Data.Models;
    using GamingUniversityApp.Services.Mapping;
    public class DeleteCourseViewModel : IMapFrom<Course>
    {
        public string Id { get; set; } = null!;
        public string? CourseName { get; set; }
        public string? Description { get; set; }
    }
}