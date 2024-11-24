namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using AutoMapper;
    using Data.Models;
    using GamingUniversityApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
    public class AddAssignmentFormModel  // : IHaveCustomMappings
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        // Dropdown list of courses to select from
        public Guid SelectedCourseId { get; set; }

        // Make sure this is using Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        public IEnumerable<SelectListItem> Courses { get; set; } = new List<SelectListItem>();

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<AddAssignmentFormModel, Assignment>()
        //        .ForMember(d => d.DueDate, x => x.Ignore());
        //}
    }
}