using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingUniversityApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
	}
}
