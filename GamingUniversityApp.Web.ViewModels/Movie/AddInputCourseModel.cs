using System.ComponentModel.DataAnnotations;
using static GamingUniversityApp.Common.EntityValidationConstants.Course;
using static GamingUniversityApp.Common.EntityValidationMessages.Course;
namespace GamingUniversityApp.Web.ViewModels.Movie
{
	public class AddInputCourseModel 
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
		//public void CreateMappings(IProfileExpression configuration)
  //      {
  //          configuration.CreateMap<AddMovieInputModel, Movie>()
  //              .ForMember(d => d.ReleaseDate, x => x.Ignore());
  //      }
    }
}
