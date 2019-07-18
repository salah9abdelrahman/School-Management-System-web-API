using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.ViewModels
{
    public class ExamViewModel
    {


        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public decimal MaxExamDegree { get; set; }


        public string CourseName { get; set; }
    }
}