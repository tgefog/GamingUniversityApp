using System.ComponentModel.DataAnnotations;

namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    public class AddAssignmentToCourseViewModel
    {
        [Required]
        public string Id {  get; set; } = null!;
        public string Name { get; set; } = null!;

    }
}
