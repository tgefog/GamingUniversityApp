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
        public Task AddAssignmentAsync(AddAssignmentFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentDetailsViewModel> GetAssignmentDetailsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
