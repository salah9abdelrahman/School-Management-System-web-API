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
        public int TeacherCourseId { get; set; }
        public string TeacherId { get; set; }
        public int CourseId { get; set; }



    }
}