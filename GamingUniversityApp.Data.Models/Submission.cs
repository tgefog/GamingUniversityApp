namespace GamingUniversityApp.Data.Models
{
    public class Submission
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual Assignment Assignment { get; set; } = null!;
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;
        public DateTime SubmissionDate { get; set; }
        public string Content { get; set; } = null!;
        public string Grade { get; set; } = null!;
    }
}
