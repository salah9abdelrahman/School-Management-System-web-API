using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Teacher
    {

        public Teacher()
        {
            TeacherCourses = new HashSet<TeacherCourse>();
            Sessions = new HashSet<Session>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TeacherId { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }

    }
}
