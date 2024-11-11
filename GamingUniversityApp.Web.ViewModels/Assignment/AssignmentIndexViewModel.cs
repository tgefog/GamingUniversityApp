using GamingUniversityApp.Services.Mapping;

namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using Data.Models;
    public class AssignmentIndexViewModel : IMapFrom<Assignment>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
