namespace GamingUniversityApp.Services.Data.Interfaces
{
    using GamingUniversityApp.Web.ViewModels.Assignment;
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentIndexViewModel>> IndexGetAllAsync();
        Task AddAssignmentAsync(AddAssignmentFormModel model);
        Task<AssignmentDetailsViewModel?> GetAssignmentDetailsByIdAsync(Guid id);
        Task<AddAssignmentToCourseViewModel?> GetAddAssignmentToCourseViewModelByIdAsync(Guid id);
        Task<bool> AddAssignmentToCourseAsync(Guid assignmentId, AddAssignmentToCourseViewModel model);
    }
}
