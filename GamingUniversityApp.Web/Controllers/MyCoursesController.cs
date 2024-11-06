using GamingUniversityApp.Data;
using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Web.ViewModels.MyCourses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Web.Controllers
{
    [Authorize]
    public class MyCoursesController : BaseController
    {
        private readonly GamingUniversityAppDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public MyCoursesController(GamingUniversityAppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(User)!;

            IEnumerable<ApplicationUserCoursesViewModel> myCourses = await this.dbContext
                .UsersCourses
                .Include(uc => uc.Course)
                .Where(uc => uc.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(uc => new ApplicationUserCoursesViewModel()
                {
                    CourseId = uc.CourseId.ToString(),
                    CourseName = uc.Course.CourseName,
                    Description = uc.Course.Description,
                    Credits = uc.Course.Credits,
                    ImageUrl = uc.Course.ImageUrl
                }).ToListAsync();

            return View(myCourses);
        }
        [HttpPost]
        public async Task<IActionResult> AddToMyCourses(string courseId)
        {
            Guid courseGuid = Guid.Empty;

            if (this.IsGuidValid(courseId, ref courseGuid))
            {
                return this.RedirectToAction("Index", "Course");
            }

            Course? course = await this.dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseGuid);
            if (course == null)
            {
                return this.RedirectToAction("Index", "Course");
            }
            Guid userGuid = Guid.Parse(this.userManager.GetUserId(this.User)!);
            bool addedToMyCoursesAlready = await this.dbContext.UsersCourses
                .AnyAsync(uc => uc.ApplicationUserId == userGuid && uc.CourseId == courseGuid);
            if (!addedToMyCoursesAlready)
            {
                ApplicationUserCourse newUserCourse = new ApplicationUserCourse()
                {

                    ApplicationUserId = userGuid,
                    CourseId = courseGuid
                };
                await this.dbContext.UsersCourses.AddAsync(newUserCourse);
                await this.dbContext.SaveChangesAsync();
            }
            return this.RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromMyCourses(string courseId)
        {
            Guid courseGuid = Guid.Empty;

            if (this.IsGuidValid(courseId, ref courseGuid))
            {
                return this.RedirectToAction("Index", "Course");
            }

            Course? course = await this.dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseGuid);
            if (course == null)
            {
                return this.RedirectToAction("Index", "Course");
            }
            Guid userGuid = Guid.Parse(this.userManager.GetUserId(this.User)!);
            ApplicationUserCourse? applicationUserCourse = await this.dbContext
                .UsersCourses
                .FirstOrDefaultAsync(uc => uc.ApplicationUserId == userGuid && uc.CourseId == courseGuid);
            if (applicationUserCourse != null)
            {
                this.dbContext.UsersCourses.Remove(applicationUserCourse);
                await this.dbContext.SaveChangesAsync();
            }
            return this.RedirectToAction(nameof(Index));
        }
    }
}
