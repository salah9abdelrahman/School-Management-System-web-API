using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_managment_system.Models
{
    public class Exam
    {
        public Exam()
        {
            Results = new HashSet<Result>();
        }
        public int ExamId { get; set; }
        [Required]
        public string ExamName { get; set; }
        public decimal MaxExamDegree { get; set; }

     


        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<Result>Results  { get; set; }
    }
}