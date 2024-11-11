using GamingUniversityApp.Data;
using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Web.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Web.Controllers
{
	public class CourseController : BaseController
	{
		private readonly GamingUniversityAppDbContext dbContext;
		private readonly ICourseService courseService;

		//Dependency injection
		public CourseController(GamingUniversityAppDbContext dbContext, ICourseService courseService)
		{
			this.dbContext = dbContext;
			this.courseService = courseService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<CourseIndexViewModel> allCourses = await this.courseService
				.IndexGetAllAsync();

			return View(allCourses);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AddInputCourseModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}
			await this.courseService.AddCourseAsync(model);

			return this.RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public async Task<IActionResult> Details(string? id)
		{
			Guid courseGuid = Guid.Empty;
			bool isGuidValid = this.IsGuidValid(id, ref courseGuid);
			if (!isGuidValid)
			{
				// Invalid id format
				return this.RedirectToAction(nameof(Index));
			}
			Course? course = await this.dbContext.Courses
			.FirstOrDefaultAsync(c => c.Id == courseGuid);
			//MovieDetailsViewModel? movie = await this.movieService
			//    .GetMovieDetailsByIdAsync(movieGuid);
			if (course == null)
			{
				// Non-existing movie guid
				return this.RedirectToAction(nameof(Index));
			}

			return this.View(course);
		}
	}
}
