namespace GamingUniversityApp.Services.Data.Interfaces
{
	public interface ILecturerService
	{
		Task<bool> IsUserLecturerAsync(string? userId);
	}
}
