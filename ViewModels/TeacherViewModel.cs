using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class TeacherViewModel
    {
        public string TeacherSNN { get; set; }

        public string FName { get; set; }
       
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
       // public int SSN { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }

        public List<string> CourseName { get; set; }






    }
}