namespace GamingUniversityApp.Web.ViewModels.Assignment
{
	using Data.Models;
	using Services.Mapping;
	public class AssignmentDetailsViewModel : IMapFrom<Assignment>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
