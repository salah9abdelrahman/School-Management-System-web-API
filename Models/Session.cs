﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Session
    {
        public Session()
        {
            Attendences = new HashSet<Attendence>();
        }
        public int SessionId { get; set; }
        public DateTime  StartDate {get; set;}
       // public DateTime  EndDate {get; set;}
        public ICollection<Attendence> Attendences  { get; set; }
        public int TeacherCourseId { get; set; }

    }
}