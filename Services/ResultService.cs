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
                var student = context.Students.Find(snn);
                var studentResult = context.Results.Where(x => x.StudentId == student.StudentId).ToList();
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
            using (var context =
                new FinalSchool())
            {
                var course = context.Courses.FirstOrDefault(x => x.Name == courseName);
                var resultExamsToCourse = context.Exams.Where(x => x.CourseId == course.CourseId).ToList();
                var ExamIds = new List<int>();         

                foreach (var item in resultExamsToCourse)
                {
                    var id = item.ExamId;
                    ExamIds.Add(id);
                }
                var resultsToOneCourseByExamIdList = new List<Result>();
                foreach (var item in ExamIds)
                {
                    var result = context.Results.FirstOrDefault(x => x.ExamId == item);
                    if (result != null)
                    {
                                    resultsToOneCourseByExamIdList.Add(result);

                    }

                }
                var resultToStudent = resultsToOneCourseByExamIdList.Where(x => x.StudentId == studentId).ToList();
                var resultToStudentViewList = new List<ResultViewModel>();
                foreach (var item in resultToStudent)
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