﻿namespace GamingUniversityApp.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Data.Interfaces;
	using ViewModels.Assignment;

	public class AssignmentController : BaseController
    {
        private readonly IAssignmentService assignmentService;
        public AssignmentController(IAssignmentService assignmentService, ILecturerService lecturerService)
            :base(lecturerService)
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
    }
}