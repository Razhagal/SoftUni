using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            //Courses = new HashSet<Course>();
            Homeworks = new HashSet<Homework>();

            StudentsCourses = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        //public ICollection<Course> Courses { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}