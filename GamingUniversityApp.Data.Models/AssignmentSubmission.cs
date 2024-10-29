using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingUniversityApp.Data.Models
{
	public class AssignmentSubmission
	{
		[Key]
		[Comment("Unique identifier")]
		public Guid Id { get; set; }
		[Required]
		[Comment("Unique identifier of the assignment")]
		public Guid AssignmentId { get; set; }
		[Required]
		[ForeignKey(nameof(AssignmentId))]
		public Assignment Assignment { get; set; } = null!;// Link to the specific assignment
		//[Required]
		//[Comment("Unique identifier of the student")]
		//public Guid StudentId { get; set; }
		//[Required]
		//[ForeignKey(nameof(StudentId))]
		//public Student Student { get; set; } = null!;// The student who submitted
		[Required]
		[Comment("Content of the submission")]
		public string Content { get; set; } = null!;// Could be a file path, URL, or text submission
		[Required]
		[Comment("Date of the submission")]
		public DateTime SubmissionDate { get; set; }
		[Required]
		[Comment("Shows if the submission already has a grade")]
		public bool IsGraded { get; set; }
		[Required]
		public string Grade { get; set; } = null!; // e.g., "A" or "Pass"
	}
}
