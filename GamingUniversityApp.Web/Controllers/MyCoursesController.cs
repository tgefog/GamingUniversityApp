namespace GamingUniversityApp.Web.Controllers
{
	using Data.Models;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.Data.Interfaces;
	using ViewModels.MyCourses;
	using static Common.ErrorMessages.MyCourses;
	[Authorize]
	public class MyCoursesController : BaseController
	{
		private readonly IMyCoursesService myCoursesService;
		private readonly UserManager<ApplicationUser> userManager;
		public MyCoursesController(IMyCoursesService myCoursesService, UserManager<ApplicationUser> userManager, ILecturerService lecturerService)
			: base(lecturerService)
		{
			this.myCoursesService = myCoursesService;
			this.userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			string userId = this.userManager.GetUserId(User)!;
			if (string.IsNullOrWhiteSpace(userId))
			{
				return this.RedirectToPage("/Identity/Account/Login");
			}
			IEnumerable<ApplicationUserCoursesViewModel> myCourses = await this.myCoursesService
				.GetUserCoursesByUserIdAsync(userId);

			return View(myCourses);
		}
		[HttpPost]
		public async Task<IActionResult> AddToMyCourses(string courseId)
		{
			string userId = this.userManager.GetUserId(User)!;
			if (string.IsNullOrWhiteSpace(userId))
			{
				return this.RedirectToPage("/Identity/Account/Login");
			}

			bool result = await this.myCoursesService
				.AddToUserCoursesAsync(courseId, userId);
			if (result == false)
			{
				TempData[nameof(AddToMyCoursesNotSuccessfullMessage)] = AddToMyCoursesNotSuccessfullMessage;
				return this.RedirectToAction("Index", "Course");
			}
			return this.RedirectToAction(nameof(Index));
		}
		[HttpPost]
		public async Task<IActionResult> RemoveFromMyCourses(string courseId)
		{
			string userId = this.userManager.GetUserId(User)!;
			if (string.IsNullOrWhiteSpace(userId))
			{
				return this.RedirectToPage("/Identity/Account/Login");
			}
			bool result = await this.myCoursesService
				.RemoveCourseFromUserCoursesAsync(courseId, userId);
			if (result == false)
			{
				TempData[nameof(AddToMyCoursesNotSuccessfullMessage)] = AddToMyCoursesNotSuccessfullMessage;
				return this.RedirectToAction("Index", "Movie");
			}
			return this.RedirectToAction(nameof(Index));
		}
	}
}
