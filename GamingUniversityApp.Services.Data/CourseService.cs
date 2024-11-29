namespace GamingUniversityApp.Services.Data
{
    using GamingUniversityApp.Data.Models;
    using GamingUniversityApp.Data.Repository.Interfaces;
    using GamingUniversityApp.Services.Mapping;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Web.ViewModels.Course;
    using Web.ViewModels.Assignment;
    public class CourseService : BaseService, ICourseService
    {
        private readonly IRepository<Course, Guid> courseRepository;
        public CourseService(IRepository<Course, Guid> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseIndexViewModel>> IndexGetAllAsync()
        {
            var allCourses = await this.courseRepository
                .GetAllAttached()
                .Where(c => !c.IsDeleted)
                .Include(c => c.Lecturer)
                .Select(c => new CourseIndexViewModel
                {
                    Id = c.Id.ToString(),
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Credits = c.Credits,
                    ImageUrl = c.ImageUrl,
                    LecturerName = $"{c.Lecturer.User.FirstName} {c.Lecturer.User.LastName}"
                })
                .ToArrayAsync();
            //IEnumerable<CourseIndexViewModel> allCourses = await this.courseRepository
            //    .GetAllAttached()
            //    .Where(c => !c.IsDeleted)
            //    .To<CourseIndexViewModel>()
            //    .ToArrayAsync();

            return allCourses;
        }
        public async Task AddCourseAsync(AddInputCourseModel model)
        {
            Course course = new Course();
            AutoMapperConfig.MapperInstance.Map(model, course);

            await this.courseRepository.AddAsync(course);
        }

        public async Task<CourseDetailsViewModel?> GetCourseDetailsByIdAsync(Guid id)
        {
            //Course course = await this.courseRepository.GetByIdAsync(id);
            //CourseDetailsViewModel viewModel = new CourseDetailsViewModel();
            //if (course != null)
            //{
            //	AutoMapperConfig.MapperInstance.Map(course, viewModel);
            //}
            Course? course = await this.courseRepository
                .GetAllAttached()
                .Include(c => c.Assignments)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            CourseDetailsViewModel? viewModel = null;
            if (course != null)
            {
                viewModel = new CourseDetailsViewModel
                {
                    Id = course.Id.ToString(),
                    CourseName = course.CourseName,
                    Description = course.Description,
                    Credits = course.Credits,
                    ImageUrl = course.ImageUrl ?? string.Empty,
                    Assignments = course.Assignments
                        .Where(a => !a.IsDeleted)
                        .Select(a => new AssignmentInCourseViewModel
                        {
                            Id = a.Id.ToString(),
                            Name = a.Name,
                            Description = a.Description,
                            DueDate = a.DueDate
                        })
                        .ToList()
                };
            }

            return viewModel;
        }

        public async Task<EditCourseModel?> GetCourseForEditByIdAsync(Guid id)
        {
            EditCourseModel? courseModel = await this.courseRepository
                .GetAllAttached()
                .Where(c => !c.IsDeleted)
                .To<EditCourseModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());
            return courseModel;
        }

        public async Task<bool> EditCourseAsync(EditCourseModel model)
        {
            Course courseEntity = AutoMapperConfig.MapperInstance
                .Map<EditCourseModel, Course>(model);
            bool result = await this.courseRepository.UpdateAsync(courseEntity);
            return result;
        }
        public async Task<DeleteCourseViewModel?> GetCourseForDeleteByIdAsync(Guid id)
        {
            DeleteCourseViewModel? courseToDelete = await this.courseRepository
                .GetAllAttached()
                .Where(c => !c.IsDeleted)
                .To<DeleteCourseViewModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return courseToDelete;
        }
        public async Task<bool> SoftDeleteCourseAsync(Guid id)
        {
            Course courseTodelete = await this.courseRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (courseTodelete == null)
            {
                return false;
            }
            courseTodelete.IsDeleted = true;
            return await this.courseRepository.UpdateAsync(courseTodelete);
        }
    }
}