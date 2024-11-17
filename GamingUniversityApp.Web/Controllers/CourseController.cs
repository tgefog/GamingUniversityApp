
namespace GamingUniversityApp.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Data.Interfaces;
	using ViewModels.Course;

	public class CourseController : BaseController
	{
		//Dependency injection
		private readonly ICourseService courseService;
		public CourseController(ICourseService courseService, ILecturerService lecturerService)
			:base(lecturerService)
		{
			this.courseService = courseService;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{

			IEnumerable<CourseIndexViewModel> allCourses = await this.courseService
				.IndexGetAllAsync();

			return this.View(allCourses);
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Create()
		{
			bool isLecturer = await this.IsUserLecturerAsync();
			if (!isLecturer)
			{
				return this.RedirectToAction(nameof(Index));
			}
			return View();
		}
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(AddInputCourseModel model)
		{
			bool isLecturer = await this.IsUserLecturerAsync();
			if (!isLecturer)
			{
				return this.RedirectToAction(nameof(Index));
			}
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
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Manage()
		{
			bool isLecturer = await this.IsUserLecturerAsync();
			if (!isLecturer)
			{
				return this.RedirectToAction(nameof(Index));
			}
			IEnumerable<CourseIndexViewModel> courses = await this.courseService
				.IndexGetAllAsync();
			return this.View(courses);
		}
	}
}