using GamingUniversityApp.Data;
using GamingUniversityApp.Web.ViewModels.Assignment;
using Microsoft.AspNetCore.Mvc;

namespace GamingUniversityApp.Web.Controllers
{
    public class AssignmentController : Controller
	{
		private readonly GamingUniversityAppDbContext _dbContext;
        public AssignmentController(GamingUniversityAppDbContext dbContext)
        {
			_dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<AssignmentIndexViewModel> assignments = _dbContext
                .Assignments
                .Select(a => new AssignmentIndexViewModel()
                {
                    Id = a.Id.ToString(),
                    Name = a.Name,
                    Description = a.Description,
                    DueDate = a.DueDate,
                    CourseName = a.Course.CourseName
                })
                .ToArray();

            return this.View(assignments);
        }
    }
}
