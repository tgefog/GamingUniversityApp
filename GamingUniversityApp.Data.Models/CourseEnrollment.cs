using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingUniversityApp.Data.Models
{
    public class CourseEnrollment
    {
        //[Key]
        //[Comment("Unique identifier")]
        //public Guid Id { get; set; }
        //[Required]
        //[Comment("Unique identifier of the student")]
        //public int StudentId { get; set; }
        //[Required]
        //[ForeignKey(nameof(StudentId))]
        //public Student Student { get; set; } = null!;
        //[Required]
        //[Comment("Unique identifier of the course")]
        //public int CourseId { get; set; }
        //[Required]
        //[ForeignKey(nameof(CourseId))]
        //public Course Course { get; set; } = null!;
        //[Required]
        //[Comment("Date of the enrollment")]
        //public DateTime EnrollmentDate { get; set; }
        //[Comment("Grade of the student for this course")]
        //public string Grade { get; set; } // Optional
    }
}
