using GamingUniversityApp.Services.Mapping;
using GamingUniversityApp.Web.ViewModels.Course;

namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using Data.Models;
    public class AssignmentDetailsViewModel : IMapFrom<Assignment>
    {
        //public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
