using GamingUniversityApp.Data;
using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Web.ViewModels.Course;
using Microsoft.AspNetCore.Mvc;

namespace GamingUniversityApp.Web.Controllers
{
	public class CourseController : BaseController
    {
        private readonly GamingUniversityAppDbContext dbContext;
        private static List<Course> courses = new List<Course>();
        //Dependency injection
        public CourseController(GamingUniversityAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Course> allCourses = this.dbContext
                .Courses
                .ToList();
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
        public IActionResult Create(AddInputCourseModel inputModel)
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
			this.dbContext.Courses.Add(course);
			this.dbContext.SaveChanges();


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
        public IActionResult Details(string? id)
        {
            Guid courseGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref courseGuid);
            if (!isGuidValid)
            {
                // Invalid id format
                return this.RedirectToAction(nameof(Index));
            }
            Course? course = this.dbContext.Courses
		    .FirstOrDefault(c => c.Id == courseGuid);
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
