namespace GamingUniversityApp.Data.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}