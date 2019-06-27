using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            Exams = new HashSet<Exam>();
            TeacherCourses = new HashSet<TeacherCourse>();
        }
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }

        public int LevelId { get; set; }
        public virtual Level Level { get; set; }

        public virtual ICollection<Session> Sessions  { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<TeacherCourse> TeacherCourses { get; set; }


    }
}