namespace GamingUniversityApp.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using GamingUniversityApp.Data.Models;
	using GamingUniversityApp.Data.Repository.Interfaces;
	using Interfaces;
	using Mapping;
	using GamingUniversityApp.Web.ViewModels.MyCourses;

	public class MyCoursesService : BaseService, IMyCoursesService
	{

		private readonly IRepository<ApplicationUserCourse, object> userCourseRepository;
		private readonly IRepository<Course, Guid> courseRepository;
		public MyCoursesService(IRepository<ApplicationUserCourse, object> userCourseRepository, IRepository<Course, Guid> courseRepository)
		{
			this.userCourseRepository = userCourseRepository;
			this.courseRepository = courseRepository;
		}

		public async Task<IEnumerable<ApplicationUserCoursesViewModel>> GetUserCoursesByUserIdAsync(string userId)
		{
			IEnumerable<ApplicationUserCoursesViewModel> myCourses = await this.userCourseRepository
				.GetAllAttached()
				.Include(uc => uc.Course)
				.Where(uc => uc.ApplicationUserId.ToString().ToLower() == userId.ToLower())
				.To<ApplicationUserCoursesViewModel>()
				.ToListAsync();

			return myCourses;
		}
		public async Task<bool> AddToUserCoursesAsync(string? courseId, string userId)
		{
			Guid courseGuid = Guid.Empty;
			if (!this.IsGuidValid(courseId, ref courseGuid))
			{
				return false;
			}

			Course? course = await this.courseRepository
				.GetByIdAsync(courseGuid);
			if (course == null)
			{
				return false;
			}
			Guid userGuid = Guid.Parse(userId);

			ApplicationUserCourse? addedToMyCoursesAlready = await this.userCourseRepository
				.FirstOrDefaultAsync(uc => uc.CourseId == courseGuid && uc.ApplicationUserId == userGuid);
			if (addedToMyCoursesAlready == null)
			{
				ApplicationUserCourse newUserCourse = new ApplicationUserCourse()
				{

					ApplicationUserId = userGuid,
					CourseId = courseGuid
				};
				await this.userCourseRepository.AddAsync(newUserCourse);
			}
			return true;
		}
		public async Task<bool> RemoveCourseFromUserCoursesAsync(string? courseId, string userId)
		{
			Guid courseGuid = Guid.Empty;

			if (!this.IsGuidValid(courseId, ref courseGuid))
			{
				return false;
			}

			Course? course = await this.courseRepository.GetByIdAsync(courseGuid);

			if (course == null)
			{
				return false;
			}
			Guid userGuid = Guid.Parse(userId);

			//TODO: Implement soft-delete
			ApplicationUserCourse? applicationUserCourse = await this.userCourseRepository
				.FirstOrDefaultAsync(uc => uc.CourseId == courseGuid && uc.ApplicationUserId == userGuid);
			if (applicationUserCourse != null)
			{
				await this.userCourseRepository.DeleteAsync(applicationUserCourse);
			}
			return true;
		}
	}
}