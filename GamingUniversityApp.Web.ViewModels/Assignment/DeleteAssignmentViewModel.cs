namespace GamingUniversityApp.Web.ViewModels.Assignment
{
    using Data.Models;
    using GamingUniversityApp.Services.Mapping;
    public class DeleteAssignmentViewModel : IMapFrom<Assignment>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}