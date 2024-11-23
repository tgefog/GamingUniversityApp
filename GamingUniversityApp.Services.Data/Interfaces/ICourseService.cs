namespace GamingUniversityApp.Services.Data.Interfaces
{
	using GamingUniversityApp.Web.ViewModels.Course;
	public interface ICourseService
	{
		Task<IEnumerable<CourseIndexViewModel>> IndexGetAllAsync();
		Task AddCourseAsync(AddInputCourseModel model);
		Task<CourseDetailsViewModel?> GetCourseDetailsByIdAsync(Guid id);
		Task<EditCourseModel?> GetCourseForEditByIdAsync(Guid id);
		Task<bool> EditCourseAsync(EditCourseModel model);
		Task<DeleteCourseViewModel?> GetCourseForDeleteByIdAsync(Guid id);
		Task<bool> SoftDeleteCourseAsync(Guid id);
	}
}
