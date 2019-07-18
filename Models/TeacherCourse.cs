using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class TeacherCourse
    {
        public TeacherCourse()
        {
            Sessions = new HashSet<session>();
        }

        public int TeacherCourseId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}