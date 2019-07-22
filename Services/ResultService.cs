using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class ResultService
    {
        public static IEnumerable<ResultViewModel> GetToStudent(string snn)
        {
            using (var context = new FinalSchool())
            {
                var studentResultViewList = new List<ResultViewModel>();
                var studentResult = from student in context.Students
                                    join result in context.Results
                                    on student.StudentId equals result.StudentId
                                    where student.StudentId == snn
                                    select result;
                foreach (var item in studentResult)
                {
                    var studentResultView = new ResultViewModel()
                    {
                        StudentId = item.StudentId,
                        ExamId = item.ExamId,
                        StudentResult = item.StudentResult
                    };
                    studentResultViewList.Add(studentResultView);
                    
                }
                return studentResultViewList;
            }
        }

        public static IEnumerable<ResultViewModel> GetToCourse(string courseName, string studentId)
        {
            using (var context =new FinalSchool())
            {
                var course = context.Courses.FirstOrDefault(x => x.Name == courseName);
                var courseExamsResults = from exam in context.Exams
                                         join cour in context.Courses
                                         on exam.CourseId equals cour.CourseId
                                         where cour.CourseId == course.CourseId
                                         join result in context.Results
                                         on exam.ExamId equals result.ExamId
                                         select result;

                var studentResults = from student in context.Students
                                     join result in courseExamsResults
                                     on student.StudentId equals result.StudentId
                                     where student.StudentId == studentId
                                     select result;

                var resultToStudentViewList = new List<ResultViewModel>();
                foreach (var item in studentResults)
                {
                    var result = new ResultViewModel
                    {
                        ExamId = item.ExamId,
                        StudentId = item.StudentId,
                        StudentResult = item.StudentResult
                    };
                    resultToStudentViewList.Add(result);
                }
                return resultToStudentViewList;
            }
            
        }

        public static void Create(List<ResultViewModel> resultViewModels)
        {
            int examId = resultViewModels[0].ExamId;
            var results = new List<Result>();
            foreach (var res in resultViewModels)
            {
                var result = new Result
                {
                    ExamId = examId,
                    StudentId = res.StudentId,
                    StudentResult = res.StudentResult
                };
                results.Add(result);
            }
            using (var context = new FinalSchool())
            {
                context.Results.AddRange(results);
                context.SaveChanges();
            }
        }
    }
}