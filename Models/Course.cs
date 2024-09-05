using System.ComponentModel.DataAnnotations;

namespace StudentCourseOneToOne.Models
{
    public class Course
    {
        public virtual int CourseId { get; set; }

        [Required(ErrorMessage = "Please Enter Course Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Course can only contain letters and spaces.")]
        public virtual string CourseName { get; set; }

        [Required(ErrorMessage = "Please Enter Duration")]
        public virtual string Duration { get; set; }

        public virtual Student Student { get; set; }
    }
}