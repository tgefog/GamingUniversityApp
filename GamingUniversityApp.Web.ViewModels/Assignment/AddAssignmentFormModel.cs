namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
    public class AddAssignmentFormModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime DueDate { get; set; }

        // Dropdown list of courses to select from
        public Guid SelectedCourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
    }
}
