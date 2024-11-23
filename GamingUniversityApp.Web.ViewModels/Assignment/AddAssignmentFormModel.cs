using GamingUniversityApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using Data.Models;
    public class AddAssignmentFormModel : IHaveCustomMappings<Assignment>
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

		// Make sure this is using Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
		public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
	}
}