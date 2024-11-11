namespace GamingUniversityApp.Services.Data.Interfaces
{
    using GamingUniversityApp.Web.ViewModels.Course;
    public interface ICourseService
    {
        Task<IEnumerable<AddInputCourseModel>> IndexGetAllAsync();
        Task AddCourseAsync(AddInputCourseModel model);
        Task<AddInputCourseModel> GetCourseDetailsByIdAsync(Guid id);

    }
}
