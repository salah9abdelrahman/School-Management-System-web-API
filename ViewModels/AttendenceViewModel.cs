using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class AttendenceViewModel
    {
        public string StudentSNN { get; set; }
        public DateTime SessionDate { get; set; }
        public bool IsAttended { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }

        public string TeacherSNN { get; set; }
    }
}