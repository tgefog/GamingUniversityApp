using GamingUniversityApp.Services.Data.Interfaces;
using GamingUniversityApp.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GamingUniversityApp.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly ILecturerService lecturerService;
		public BaseController(ILecturerService lecturerService)
		{
			this.lecturerService = lecturerService;
		}
		protected bool IsGuidValid(string? id, ref Guid parsedGuid)
		{
			// Non-existing parameter in the URL
			if (String.IsNullOrWhiteSpace(id))
			{
				return false;
			}

			// Invalid parameter in the URL
			bool isGuidValid = Guid.TryParse(id, out parsedGuid);
			if (!isGuidValid)
			{
				return false;
			}

			return true;
		}

		protected async Task<bool> IsUserLecturerAsync()
		{
			string? userId = this.User.GetUserId();
			bool isLecturer = await this.lecturerService.IsUserLecturerAsync(userId);

			return isLecturer;
		}
	}
}