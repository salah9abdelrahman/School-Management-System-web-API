using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class AttendenceViewModel
    {

        public DateTime SessionDate { get; set; }
        public bool IsAttended { get; set; }
        public StudentViewModel Student { get; set; }
        public CourseViewModel   Course { get; set; }
        public TeacherViewModel   Teacher { get; set; }
        //public int TeacherId { get; set; }

    }
}