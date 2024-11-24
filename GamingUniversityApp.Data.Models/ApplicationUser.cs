namespace GamingUniversityApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}