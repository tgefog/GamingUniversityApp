namespace GamingUniversityApp.Web.ViewModels.Course
{
    using GamingUniversityApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static GamingUniversityApp.Common.EntityValidationConstants.Course;
    using static GamingUniversityApp.Common.EntityValidationMessages.Course;
    using AutoMapper;

    public class EditCourseModel : IHaveCustomMappings
    {
        public string Id { get; set; } = null!;
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Course, EditCourseModel>();

            configuration.CreateMap<EditCourseModel, Course>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
