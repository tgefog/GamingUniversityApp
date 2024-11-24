namespace GamingUniversityApp.Services.Data
{
    using GamingUniversityApp.Data.Models;
    using GamingUniversityApp.Data.Repository.Interfaces;
    using GamingUniversityApp.Web.ViewModels.Lecturer;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class LecturerService : BaseService, ILecturerService
	{
		private readonly IRepository<Lecturer, Guid> lecturersRepository;
		public LecturerService(IRepository<Lecturer, Guid> lecturersRepository)
		{
			this.lecturersRepository = lecturersRepository;
		}
		public async Task<bool> IsUserLecturerAsync(string? userId)
		{
			if (String.IsNullOrWhiteSpace(userId))
			{
				return false;
			}

			bool result = await this.lecturersRepository
				.GetAllAttached()
				.AnyAsync(l => l.UserId.ToString().ToLower() == userId.ToLower());

			return result;
		}
        public async Task<IEnumerable<LecturerViewModel>> GetAllLecturersAsync()
        {
			var lecturers = await this.lecturersRepository.GetAllAsync();
			return lecturers.Select(l => new LecturerViewModel
			{
				Id = l.Id.ToString(),
				FullName = $"{l.User.FirstName} {l.User.LastName}"
			});
		}
    }
}
