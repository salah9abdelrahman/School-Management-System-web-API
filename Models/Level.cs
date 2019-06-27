using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Level
    {

        public Level()
        {

            Courses = new HashSet<Course>();
            ClassRooms = new HashSet<ClassRoom>();

        }
        public int LevelId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}