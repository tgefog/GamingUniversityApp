using GamingUniversityApp.Data.Models;
using GamingUniversityApp.Web.ViewModels.Lecturer;

namespace GamingUniversityApp.Services.Data.Interfaces
{
	public interface ILecturerService
	{
		Task<bool> IsUserLecturerAsync(string? userId);
		Task<IEnumerable<LecturerViewModel>> GetAllLecturersAsync();
	}
}
