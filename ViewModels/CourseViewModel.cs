using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class CourseViewModel
    {

        public int CourseId { get; set; }
        
        
        public string Name { get; set; }

        public string LevelName { get; set; }
       // public int LevelId { get; set; }


    }
}