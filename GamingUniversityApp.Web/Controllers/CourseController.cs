﻿namespace GamingUniversityApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Data.Interfaces;
    using ViewModels.Course;
    using static GamingUniversityApp.Common.ErrorMessages.Course;

    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService, ILecturerService lecturerService)
            : base(lecturerService)
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
			var lecturers = await this.lecturerService.GetAllLecturersAsync(); // Ensure this returns valid data
			ViewBag.Lecturers = new SelectList(lecturers, "Id", "FullName");
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
            var lecturers = await this.lecturerService.GetAllLecturersAsync();
            ViewBag.Lecturers = new SelectList(lecturers, "Id");
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isLecturer = await this.IsUserLecturerAsync();
            Guid courseGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref courseGuid);

            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditCourseModel? model = await this.courseService
                .GetCourseForEditByIdAsync(courseGuid);

            if (model == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }
            return this.View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditCourseModel model)
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

            bool isUpdated = await this.courseService.EditCourseAsync(model);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, EditCourseNotSuccessfullMessage);
                return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Details), "Course", new { id = model.Id });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            Guid courseGuid = Guid.Empty;
            bool isLecturer = await this.IsUserLecturerAsync();
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool isIdValid = this.IsGuidValid(id, ref courseGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteCourseViewModel? courseToDelete = await this.courseService
                .GetCourseForDeleteByIdAsync(courseGuid);
            if (courseToDelete == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }
            return this.View(courseToDelete);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteCourseViewModel course)
        {
            Guid courseGuid = Guid.Empty;
            bool isLecturer = await this.IsUserLecturerAsync();
            bool isIdValid = this.IsGuidValid(course.Id, ref courseGuid);
            if (!isLecturer)
            {
                return this.RedirectToAction(nameof(Index));
            }
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }
            bool isDeleted = await this.courseService
                .SoftDeleteCourseAsync(courseGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] = DeleteCourseNotSuccessfullMessage;
                return this.RedirectToAction(nameof(Delete), new { id = course.Id });
            }
            return this.RedirectToAction(nameof(Manage));
        }
    }
}