using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class ParentViewModel
    {
        public string ParentId { get; set; }
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public int? Password { get; set; }
        public int SNN { get; set; }
    }
}