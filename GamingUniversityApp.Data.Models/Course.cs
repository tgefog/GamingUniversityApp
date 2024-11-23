namespace GamingUniversityApp.Data.Models
{
    public class Course
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Credits { get; set; }
        public Lecturer Lecturer { get; set; } = null!;
        public Guid LecturerId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new HashSet<Assignment>();
        public virtual ICollection<ApplicationUserCourse> CourseApplicationUsers { get; set; } = new HashSet<ApplicationUserCourse>();
    }
}