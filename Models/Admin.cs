using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Admin
    {

        public int AdminId { get; set; }
      
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string SNN { get; set; }
        public string Phone { get; set; }
       
    }
}