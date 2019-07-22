using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class ExamService
    {
        public static IEnumerable<ExamViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var examListModel = new List<ExamViewModel>();
                foreach (var item in context.Exams.ToList())
                {
                    examListModel.Add(new ExamViewModel
                    {
                        ExamId = item.ExamId,
                        ExamName = item.ExamName,
                        CourseName = item.Course.Name,
                        MaxExamDegree = item.MaxExamDegree
                    });

                }
                return examListModel;
            }
        }


        public static ExamViewModel GetOne(int id)
        {
            using (var context = new FinalSchool())
            {

                var exam = context.Exams.Find(id);
                var examModel = new ExamViewModel()
                {

                    ExamId = exam.ExamId,
                    ExamName = exam.ExamName,
                    CourseName = exam.Course.Name,
                    MaxExamDegree = exam.MaxExamDegree

                };
                return examModel;
            }
        }


        public static int PostOne(ExamViewModel examViewModel)
        {

            using (var context = new FinalSchool())
            {
                var courseId = context.Courses.FirstOrDefault(w => w.Name == examViewModel.CourseName).CourseId;
                var exam = new Exam()
                {
                    ExamName = examViewModel.ExamName,
                    MaxExamDegree = examViewModel.MaxExamDegree,
                    CourseId = courseId,
                };
                context.Exams.Add(exam);
                context.SaveChanges();
                return exam.ExamId;
            }
        }

        public static void PutOne(ExamViewModel examViewModel)
        {
            using (var context = new FinalSchool())
            {
                var courseId = context.Courses.FirstOrDefault(x => x.Name == examViewModel.CourseName).CourseId;
                var exam = context.Exams.Find(examViewModel.ExamId);
                exam.ExamName = examViewModel.ExamName;
                exam.CourseId = courseId;
                exam.MaxExamDegree = examViewModel.MaxExamDegree;
                context.SaveChanges();
            }

        }


        public static void DeleteOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var exam = context.Exams.Find(id);
                context.Exams.Remove(exam);
                context.SaveChanges();
            }
        }
    }
}