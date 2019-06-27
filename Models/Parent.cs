using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Parent
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }
        public int ParentId { get; set; }
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int? Password { get; set; }
        public int SNN { get; set; }
        public ICollection<Student>Students  { get; set; }
    }
}