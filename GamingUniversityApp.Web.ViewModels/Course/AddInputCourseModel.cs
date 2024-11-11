using GamingUniversityApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static GamingUniversityApp.Common.EntityValidationConstants.Course;
using static GamingUniversityApp.Common.EntityValidationMessages.Course;

namespace GamingUniversityApp.Web.ViewModels.Course

{
	using Data.Models;
	public class AddInputCourseModel : IMapTo<Course>
    {

        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]

        public string CourseName { get; set; } = null!;
        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = CreditsRequiredMessage)]
        public int Credits { get; set; }

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
