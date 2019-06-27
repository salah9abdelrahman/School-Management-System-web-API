using School_managment_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class StudentViewModel
    {

        public int StudentId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }
        public int Age { get; set; }

        public int SNN { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? JoinDate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public string ClassName { get; set; }
        public string LevelName { get; set; }
        public string ParentFName { get; set; }
        public string ParentLName { get; set; }
        public int ParentSNN { get; set; }

        //----------------------------------------------
        ///public ClassRoomViewModel Klass { get; set; }

        //public ParentViewModel Parent { get; set; }

    }
}