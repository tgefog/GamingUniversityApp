using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Data.Repository.Interfaces;
using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Services.Mapping;
using GamingUniversityApp.Web.ViewModels.Assignment;
using Microsoft.EntityFrameworkCore;

namespace GamingUniversityApp.Services.Data
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment, Guid> assignmentRepository;
        public AssignmentService(IRepository<Assignment, Guid> assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<AssignmentIndexViewModel>> IndexGetAllAsync()
        {
            IEnumerable<AssignmentIndexViewModel> assignments = await this.assignmentRepository
                .GetAllAttached()
                .To<AssignmentIndexViewModel>()
                .ToArrayAsync();

            return assignments;
        }
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

            // If assignment is null, handle invalid ID
            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment ID");
            }

            // Map assignment to AssignmentDetailsViewModel
            AssignmentDetailsViewModel detailsViewModel = AutoMapperConfig.MapperInstance
                .Map<AssignmentDetailsViewModel>(assignment);

            return detailsViewModel;
        }


    }
}
