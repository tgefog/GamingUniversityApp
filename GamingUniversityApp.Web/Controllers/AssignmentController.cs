using GamingUniversityApp.Data;
using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Web.ViewModels.Assignment;
using Microsoft.AspNetCore.Mvc;

namespace GamingUniversityApp.Web.Controllers
{
    public class AssignmentController : BaseController
    {
        private readonly IAssignmentService assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
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
                return this.View(model);
            }
            await this.assignmentService.AddAssignmentAsync(model);
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

            AssignmentDetailsViewModel? detailsViewModel = await this.assignmentService
                .GetAssignmentDetailsByIdAsync(assignmentGuid);

            //Invalid GUID in the URL
            if (detailsViewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
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