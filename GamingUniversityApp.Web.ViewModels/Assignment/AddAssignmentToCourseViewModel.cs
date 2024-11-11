using System.ComponentModel.DataAnnotations;

namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    public class AddAssignmentToCourseViewModel
    {
        [Required]
        public string Id {  get; set; } = null!;
        public string Name { get; set; } = null!;
		[StringLength(1000)]
		public string? Description { get; set; } // Assignment Description
        public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
        public Guid CourseId { get; set; }  // The selected course Id
        [Required]
		public DateTime DueDate { get; set; } // Assignment Due Date

	}
}
