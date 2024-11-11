using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Data.Repository.Interfaces;
using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Services.Mapping;
using GamingUniversityApp.Web.ViewModels.Assignment;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Services.Data
{
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
        //Old automapper implementation

        //public async Task<IEnumerable<AssignmentIndexViewModel>> IndexGetAllAsync()
        //{
        //    IEnumerable<AssignmentIndexViewModel> assignments = await this.assignmentRepository
        //        .GetAllAttached()
        //        .To<AssignmentIndexViewModel>()
        //        .ToArrayAsync();

        //    return assignments;
        //}
        public async Task AddAssignmentAsync(AddAssignmentFormModel model)
        {
            Assignment assignment = new Assignment();
            AutoMapperConfig.MapperInstance.Map(model, assignment);

            await this.assignmentRepository.AddAsync(assignment);
        }

        public async Task<AssignmentDetailsViewModel> GetAssignmentDetailsByIdAsync(Guid id)
        {
            // Fetch assignment by id
            Assignment? assignment = await this.assignmentRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment ID");
            }

            // Map assignment to view model
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

            if (course == null)
            {
                return false;
            }
            assignment.CourseId = course.Id;
            await this.assignmentRepository.AddAsync(assignment);

            return true;
        }
    }
}
