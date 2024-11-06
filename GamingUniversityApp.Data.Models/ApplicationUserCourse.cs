using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingUniversityApp.Data.Models
{
	public class ApplicationUserCourse
	{
		public Guid ApplicationUserId { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; } = null!;
		public Guid CourseId { get; set; }
		public virtual Course Course { get; set; } = null!;
	}
}
