using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace School_managment_system.Models
{
    public class Attendence
    {

        [Key,Column(Order =1)]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Key, Column(Order = 2)]
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        public bool IsAttended { get; set; }
    }
}