namespace GamingUniversityApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using ViewModels.Assignment;

    public class AssignmentController : BaseController
    {
        private readonly IAssignmentService assignmentService;
        public AssignmentController(IAssignmentService assignmentService, ILecturerService lecturerService)
            : base(lecturerService)
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
        [Authorize]
        public async Task<IActionResult> Create()
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAssignmentFormModel model)
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }

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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToCourse(string? id)
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            Guid assignmentGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref assignmentGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            AddAssignmentToCourseViewModel? viewModel = await this.assignmentService
                .GetAddAssignmentToCourseViewModelByIdAsync(assignmentGuid);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCourse(AddAssignmentToCourseViewModel model)
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

            Guid assignmentGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(model.Id, ref assignmentGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool result = await this.assignmentService
                .AddAssignmentToCourseAsync(assignmentGuid, model);
            if (result == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index), "Assignment");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            Guid assignmentGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref assignmentGuid);

            if (!isLecturer)
            {
                //TODO : Implement notifications for error and warning messages!
                return this.RedirectToAction(nameof(Index));
            }

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            EditAssignmentViewModel? model = await this.assignmentService
                .GetAssignmentForEditByIdAsync(assignmentGuid);

            if (model == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditAssignmentViewModel model)
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool isUpdated = await this.assignmentService.EditAssignmentAsync(model);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while updating the assignment! Please contact administrator");
                return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Details), "Assignment", new { id = model.Id });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            Guid assignmentGuid = Guid.Empty;
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool isIdValid = this.IsGuidValid(id, ref assignmentGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            DeleteAssignmentViewModel? assignmentToDelete = await this.assignmentService
                .GetAssignmentForDeleteByIdAsync(assignmentGuid);
            if (assignmentToDelete == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(assignmentToDelete);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteAssignmentViewModel assignment)
        {
            Guid assignmentId = Guid.Empty;
            bool isLecturer = await this.IsUserLecturerAsync();
            bool isIdValid = this.IsGuidValid(assignment.Id, ref assignmentId);
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool isDeleted = await this.assignmentService
                .SoftDeleteAssignmentAsync(assignmentId);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] = "Unexpected error occured while trying to delete the assignment! Please contact system administrator";
                return this.RedirectToAction(nameof(Delete), new { id = assignment.Id });
            }
            return this.RedirectToAction(nameof(Index));
        }
    }
}