namespace GamingUniversityApp.Web.ViewModels.Submission
{
	public class AddSubmissionViewModel
	{
		public string AssignmentId { get; set; } = null!;
		//public string StudentId { get; set; } 
		public string UserId { get; set; } = null!;
		public string Content { get; set; } = null!;
		public string Grade { get; set; } = null!;
	}
}
