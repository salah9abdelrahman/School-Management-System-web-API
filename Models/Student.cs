using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Student
    {

        public Student()
        {
            Attendences = new HashSet<Attendence>();
            Results = new HashSet<Result>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string StudentId { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public int Age { get; set; }
        [Required]
        //public int SNN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //-----------------------------------

        //public string ParentId { get; set; }
        [ForeignKey("Parent")]
        public string ParentSNN { get; set; }

        public virtual Parent Parent { get; set; }
        //-------------------------------------
       public int? ClassRoomId { get; set; }
        // ? [ForeignKey("ClassRoomId")]
        public virtual ClassRoom ClassRoom { get; set; }
        //------------------------------------------------
        public virtual ICollection<Attendence> Attendences { get; set; }
        //-------------------------
        public virtual ICollection<Result> Results { get; set; }
    }
}