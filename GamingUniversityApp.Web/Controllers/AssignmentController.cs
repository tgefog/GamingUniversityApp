using GamingUniversityApp.Data;
using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Web.ViewModels.Assignment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Web.Controllers
{
    public class AssignmentController : BaseController
    {
        private readonly GamingUniversityAppDbContext dbContext;
        private readonly IAssignmentService assignmentService;
        public AssignmentController(GamingUniversityAppDbContext dbContext, IAssignmentService assignmentService)
        {
            this.dbContext = dbContext;
            this.assignmentService = assignmentService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AssignmentIndexViewModel> assignments = await this.assignmentService
                .IndexGetAllAsync();

            return this.View(assignments);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAssignmentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload course list if model is invalid
                return this.View(model);
            }
            Assignment assignment = new Assignment()
            {
                Name = model.Name,
                Description = model.Description,
                DueDate = model.DueDate,
                CourseId = model.SelectedCourseId
            };

            await this.dbContext.Assignments.AddAsync(assignment);
            await this.dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid assignmentGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref assignmentGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            Assignment? assignment = await this.dbContext.Assignments
            .FirstOrDefaultAsync(a => a.Id == assignmentGuid);
            //Invalid GUID in the URL
            if (assignment == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            AssignmentDetailsViewModel detailsViewModel = new AssignmentDetailsViewModel()
            {
                Name = assignment.Name,
                Description = assignment.Description,
                DueDate = assignment.DueDate,
                CourseName = assignment.Course.CourseName
            };
            return this.View(detailsViewModel);

        }
        //public async Task<IActionResult> AddToCourse(string? id)
        //{
        //    Guid assignmentGuid = Guid.Empty;
        //    bool isGuidValid = this.IsGuidValid(id, ref assignmentGuid);
        //    if (!isGuidValid)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //}
    }
}