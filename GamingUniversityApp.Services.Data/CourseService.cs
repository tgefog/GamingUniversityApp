namespace GamingUniversityApp.Services.Data
{
	using GamingUniversityApp.Data.Models;
	using GamingUniversityApp.Data.Repository.Interfaces;
	using GamingUniversityApp.Services.Mapping;
	using Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using Web.ViewModels.Course;
	public class CourseService : ICourseService
    {
        private readonly IRepository<Course, Guid> courseRepository;
        public CourseService(IRepository<Course, Guid> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseIndexViewModel>> IndexGetAllAsync()
        {
            IEnumerable<CourseIndexViewModel> allCourses = await this.courseRepository
                .GetAllAttached()
                .To<CourseIndexViewModel>()
                .ToArrayAsync();

            return allCourses;
        }
		public async Task AddCourseAsync(AddInputCourseModel model)
		{
			// Map the view model to the Course entity
			Course course = new Course();
			AutoMapperConfig.MapperInstance.Map(model, course);

			await this.courseRepository.AddAsync(course);
		}

		//public Task<AddInputCourseModel> GetCourseDetailsByIdAsync(Guid id)
		//{
		//    throw new NotImplementedException();
		//}


	}
}
