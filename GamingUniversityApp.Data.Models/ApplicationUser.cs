using Microsoft.AspNetCore.Identity;

namespace GamingUniversityApp.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
    {
		public ApplicationUser() 
		{
			this.Id = Guid.NewGuid();
		}
	}
}
