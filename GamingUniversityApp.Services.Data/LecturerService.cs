namespace GamingUniversityApp.Services.Data
{
	using Microsoft.EntityFrameworkCore;
	using GamingUniversityApp.Data.Models;
	using GamingUniversityApp.Data.Repository.Interfaces;
	using Interfaces;

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
			bool result = await this.lecturersRepository.GetAllAttached().AnyAsync(l => l.UserId.ToString().ToLower() == userId.ToLower());
			return result;
		}
	}
}
