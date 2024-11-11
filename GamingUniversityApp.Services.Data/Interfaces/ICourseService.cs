namespace GamingUniversityApp.Services.Data.Interfaces
{
    using GamingUniversityApp.Web.ViewModels.Course;
    public interface ICourseService
    {
        Task<IEnumerable<CourseIndexViewModel>> IndexGetAllAsync();
        Task AddCourseAsync(AddInputCourseModel model);
        //Task<AddInputCourseModel> GetCourseDetailsByIdAsync(Guid id);

    }
}
