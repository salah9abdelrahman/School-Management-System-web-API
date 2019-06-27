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
        [Key, Column(Order =1)]
        public int TeacherId { get; set; }
        [Key, Column(Order =2)]

        public int CourseId { get; set; }



    }
}