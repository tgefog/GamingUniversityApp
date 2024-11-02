using GamingUniversityApp.Data;
using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Web.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Web.Controllers
{
	public class CourseController : BaseController
    {
        private readonly GamingUniversityAppDbContext dbContext;
        //Dependency injection
        public CourseController(GamingUniversityAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> allCourses = await this.dbContext
                .Courses
                .ToListAsync();
            //IEnumerable<AllMoviesIndexViewModel> allMovies =
            //    await this.movieService.GetAllMoviesAsync();

            return View(allCourses);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddInputCourseModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                // Render the same form with user entered values + model errors 
                return this.View(inputModel);
            }
            Course course = new Course()
            {
                CourseName = inputModel.CourseName,
                Description = inputModel.Description,
                Credits = inputModel.Credits
            };
			await this.dbContext.Courses.AddAsync(course);
			await this.dbContext.SaveChangesAsync();


			//course.Id = Guid.NewGuid();
			//dbContext.Add(inputCourse);
			//bool result = await this.movieService.AddMovieAsync(inputModel);
			//if (result == false)
			//{
			//    this.ModelState.AddModelError(nameof(inputModel.ReleaseDate),
			//        String.Format("The Release Date must be in the following format: {0}", ReleaseDateFormat));
			//    return this.View(inputModel);
			//}

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
