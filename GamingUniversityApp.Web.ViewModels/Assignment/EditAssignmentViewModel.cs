namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using AutoMapper;
    using Data.Models;
    using GamingUniversityApp.Services.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;
    using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
    using static GamingUniversityApp.Common.EntityValidationMessages.Assignment;

    public class EditAssignmentViewModel : IMapFrom<Assignment>, IMapTo<Assignment>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = NameRequiredMessage)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = DueDateRequiredMessage)]
        public string DueDate { get; set; } = null!;

        // Dropdown list of courses to select from
        public Guid SelectedCourseId { get; set; }

        // Make sure this is using Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Assignment, EditAssignmentViewModel>()
                .ForMember(d => d.DueDate, opt => opt.MapFrom(s => s.DueDate.ToString(DueDateFormat)));

            configuration.CreateMap<EditAssignmentViewModel, Assignment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DueDate, opt => opt.Ignore());
        }
    }
}
