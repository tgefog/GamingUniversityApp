namespace GamingUniversityApp.Web.ViewModels.Assignment
{
	public class AssignmentIndexViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
