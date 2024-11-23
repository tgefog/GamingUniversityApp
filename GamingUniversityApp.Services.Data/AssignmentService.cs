namespace GamingUniversityApp.Services.Data
{
    using GamingUniversityApp.Data.Models;
    using GamingUniversityApp.Data.Repository.Interfaces;
    using GamingUniversityApp.Web.ViewModels.Assignment;
    using Interfaces;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;
    public class AssignmentService : BaseService, IAssignmentService
    {
        private readonly IRepository<Assignment, Guid> assignmentRepository;
        private readonly IRepository<Course, Guid> courseRepository;
        public AssignmentService(IRepository<Assignment, Guid> assignmentRepository, IRepository<Course, Guid> courseRepository)
        {
            this.assignmentRepository = assignmentRepository;
            this.courseRepository = courseRepository;
        }
        public async Task<IEnumerable<AssignmentIndexViewModel>> IndexGetAllAsync()
        {
            IEnumerable<AssignmentIndexViewModel> assignments = await this.assignmentRepository
                .GetAllAttached()
                .Include(a => a.Course)
                .Select(a => new AssignmentIndexViewModel
                {
                    Id = a.Id.ToString(),
                    Name = a.Name,
                    Description = a.Description,
                    DueDate = a.DueDate,
                    CourseName = a.Course != null ? a.Course.CourseName : "No Course"
                })
                .ToArrayAsync();

            return assignments;
        }
        public async Task AddAssignmentAsync(AddAssignmentFormModel model)
        {
            Assignment assignment = new Assignment();
            AutoMapperConfig.MapperInstance.Map(model, assignment);

            await this.assignmentRepository.AddAsync(assignment);
        }

        public async Task<AssignmentDetailsViewModel?> GetAssignmentDetailsByIdAsync(Guid id)
        {
            Assignment? assignment = await this.assignmentRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment ID");
            }
            AssignmentDetailsViewModel detailsViewModel = AutoMapperConfig.MapperInstance
                .Map<AssignmentDetailsViewModel>(assignment);

            return detailsViewModel;
        }

        public async Task<AddAssignmentToCourseViewModel?> GetAddAssignmentToCourseViewModelByIdAsync(Guid id)
        {
            Assignment? assignment = await this.assignmentRepository.GetByIdAsync(id);

            if (assignment != null)
            {
                var viewModel = new AddAssignmentToCourseViewModel
                {
                    Id = assignment.Id.ToString(),
                    Name = assignment.Name,
                };
                var courses = await this.courseRepository.GetAllAsync();
                viewModel.Courses = courses.Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    CourseName = c.CourseName
                }).ToList();

                return viewModel;
            }

            return null;
        }

        public async Task<bool> AddAssignmentToCourseAsync(Guid assignmentId, AddAssignmentToCourseViewModel model)
        {
            var assignment = await this.assignmentRepository.GetByIdAsync(assignmentId);

            if (assignment == null)
            {
                return false;
            }
            var course = await this.courseRepository.GetByIdAsync(model.CourseId);

            if (course == null || course.IsDeleted)
            {
                return false;
            }
            assignment.CourseId = course.Id;
            await this.assignmentRepository.AddAsync(assignment);

            return true;
        }

        public async Task<EditAssignmentViewModel?> GetAssignmentForEditByIdAsync(Guid id)
        {
            //TODO : check soft delete
            EditAssignmentViewModel? editAssignmentViewModel = await this.assignmentRepository
                .GetAllAttached()
                .To<EditAssignmentViewModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return editAssignmentViewModel;
        }

        public async Task<bool> EditAssignmentAsync(EditAssignmentViewModel model)
        {
            Guid assignmentGuid = Guid.Empty;
            if (this.IsGuidValid(model.Id, ref assignmentGuid))
            {
                return false;
            }
            Assignment editedAssignment = AutoMapperConfig.MapperInstance.Map<Assignment>(model);
            editedAssignment.Id = assignmentGuid;
            bool isDueDateValid = DateTime.TryParseExact(model.DueDate, DueDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);
            if (!isDueDateValid)
            {
                return false;
            }
            editedAssignment.DueDate = dueDate;
            return await this.assignmentRepository.UpdateAsync(editedAssignment);
        }
    }
}
