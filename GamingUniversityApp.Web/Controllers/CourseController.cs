
namespace GamingUniversityApp.Web.Controllers
{
	using Services.Data.Interfaces;
	using ViewModels.Course;
	using Microsoft.AspNetCore.Mvc;

	public class CourseController : BaseController
	{
		//Dependency injection
		private readonly ICourseService courseService;
		public CourseController(ICourseService courseService)
		{
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
				return this.RedirectToAction(nameof(Index));
			}

			CourseDetailsViewModel? course = await this.courseService
				.GetCourseDetailsByIdAsync(courseGuid);

			if (course == null)
			{
				return this.RedirectToAction(nameof(Index));
			}

			return this.View(course);
		}
	}
}