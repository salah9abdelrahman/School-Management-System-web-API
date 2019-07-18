using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class ClassRoomViewModel
    {
        public int ClassId { get; set; }

        public string Name { get; set; }
        //public int LevelId { get; set; }
        public string LevelName { get; set; }
    }
}