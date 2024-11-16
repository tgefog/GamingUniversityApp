namespace GamingUniversityApp.Services.Data.Interfaces
{
    using Web.ViewModels.MyCourses;
    public interface IMyCoursesService
    {
        Task<IEnumerable<ApplicationUserCoursesViewModel>> GetUserCoursesByUserIdAsync(string userId);
        Task<bool> AddToUserCoursesAsync(string? courseId, string userId);
        Task<bool> RemoveCourseFromUserCoursesAsync(string? courseId, string userId);
    }
}
