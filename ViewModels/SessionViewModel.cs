using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class SessionViewModel
    {
        public int SessionId { get; set; }
        public DateTime StartDate { get; set; }
       // public DateTime EndDate { get; set; }


        public string  TeacherFName { get; set; }
        public string  TeacherLName { get; set; }
        public string CourseName { get; set; }


    }
}