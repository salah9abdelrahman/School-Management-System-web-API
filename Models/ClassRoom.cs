using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class ClassRoom
    {

        public ClassRoom()
        {
            Students = new HashSet<Student>();
        }
        public int ClassRoomId { get; set; }
        [Required]

       [StringLength(150)]
        public string Name { get; set; }


        public int LevelId { get; set; }
        public virtual Level Level { get; set; }

        public virtual ICollection<Student>Students { get; set; }
    }
}