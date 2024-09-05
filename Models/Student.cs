using System.ComponentModel.DataAnnotations;

namespace StudentCourseOneToOne.Models
{
    public class Student
    {

        public virtual int StudentId { get; set; }

        [Required(ErrorMessage = "Please Enter your Name")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Age")]
        [Range(16, 50, ErrorMessage = "Age must be between 16 and 50.")]
        public virtual int Age { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public virtual string Email { get; set; }

        public virtual Course Course { get; set; }
    }
}