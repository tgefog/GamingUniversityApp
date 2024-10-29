using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GamingUniversityApp.Common.EntityValidationConstants.Course;

namespace GamingUniversityApp.Data.Models
{
    public class Course
    {
        [Key]
        [Comment("Unique identifier")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Model of the aircraft")]
        public string CourseName { get; set; } = null!;  // example : "League of Legends Basics"
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Course description")]
        public string Description { get; set; } = null!;
        [Required]
        [Comment("Amount of credits given to students for completing the course")]
        public int Credits { get; set; }
        //[Required]
        //[Comment("Lecturer that is assigned to the course")]
        //public Lecturer Lecturer { get; set; } // The assigned lecturer or admin
        //[Required]
        //[Comment("Students enrolled on this course")]
        //public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();// Students enrolled
        //[Required]
        //[Comment("Assignments for this course this course")]
        //public ICollection<Assignment> Assignments { get; set; } // Assignments for this course
    }
}
