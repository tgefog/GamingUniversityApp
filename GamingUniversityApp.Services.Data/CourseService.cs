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
			Course course = new Course();
			AutoMapperConfig.MapperInstance.Map(model, course);

			await this.courseRepository.AddAsync(course);
		}

		public async Task<CourseDetailsViewModel?> GetCourseDetailsByIdAsync(Guid id)
		{
			Course course = await this.courseRepository.GetByIdAsync(id);
			CourseDetailsViewModel viewModel = new CourseDetailsViewModel();
			if (course != null)
			{
				AutoMapperConfig.MapperInstance.Map(course, viewModel);
			}
			return viewModel;
		}
	}
}