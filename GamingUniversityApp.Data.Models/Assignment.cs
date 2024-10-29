using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GamingUniversityApp.Common.EntityValidationConstants.Assignment;

namespace GamingUniversityApp.Data.Models
{
	public class Assignment
	{
		[Key]
		[Comment("Unique identifier")]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(NameMaxLength)]
		[Comment("Name of the assignment")]
		public string Name { get; set; } = null!;// e.g., "Introduction to Game Mechanics"
		[Required]
		[MaxLength(DescriptionMaxLength)]
		[Comment("Description of the assignment")]
		public string Description { get; set; } = null!;
		[Required]
		[Comment("Due date for this assignment")]
		public DateTime DueDate { get; set; }
		[Required]
		[Comment("Unique identifier of the course that the assignment belongs to")]
		public Guid CourseId { get; set; }
		[Required]
		[ForeignKey(nameof(CourseId))]
		public Course Course { get; set; } = null!;
		[Required]
		[Comment("Collection of all submissions for this assignment")]
		public ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
	}
}
