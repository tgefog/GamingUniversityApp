namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using Data.Models;
    using Services.Mapping;
    public class AssignmentInCourseViewModel : IMapFrom<Assignment>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
    }
}
