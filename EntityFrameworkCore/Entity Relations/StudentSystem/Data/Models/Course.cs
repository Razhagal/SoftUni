using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            //Students = new HashSet<Student>();
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();

            StudentsCourses = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        //public ICollection<Student> Students { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homeworks { get; set; }


        public ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}
