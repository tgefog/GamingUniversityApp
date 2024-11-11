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
        //public Task AddCourseAsync(AddInputCourseModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<AddInputCourseModel> GetCourseDetailsByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
