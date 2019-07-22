using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using School_managment_system.Models;

namespace School_managment_system.Services
{
    public class AttendenceService
    {
        public static IEnumerable<AttendenceViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var attendViewList = new List<AttendenceViewModel>();
                foreach (var attend in context.Attendences.ToList())
                {
                    var attendenceView = new AttendenceViewModel()
                    {
                        CourseName = attend.Session.Course.Name,
                        IsAttended = attend.IsAttended,
                        SessionDate = attend.Session.StartDate,
                        StudentName = attend.Student.FName + ' ' + attend.Student.LName,
                        TeacherName = attend.Session.Teacher.FName + ' ' + attend.Session.Teacher.LName,
                    };
                    attendViewList.Add(attendenceView);
                }
                return attendViewList;
            }

        }

        public static IEnumerable<AttendenceViewModel> GetAttendencesToStudent(string snn)
        {
            using (var context = new FinalSchool())
            {
                var student = context.Students.Find(snn);
                var studentAttendences = (from stu in context.Students
                                          join attend in context.Attendences
                                          on stu.StudentId equals attend.StudentId
                                          where stu.StudentId == snn
                                          select attend)
                                          .ToList();

                var studentAttendViewList = new List<AttendenceViewModel>();
                foreach (var item in studentAttendences)
                {
                    var studentAttendView = new AttendenceViewModel()
                    {
                        StudentSNN = item.StudentId,
                        CourseName = item.Session.Course.Name,
                        IsAttended = item.IsAttended,
                        SessionDate = item.Session.StartDate,
                        StudentName = item.Student.FName + ' ' + item.Student.FName,
                        TeacherName = item.Session.Teacher.FName + ' ' + item.Session.Teacher.LName,
                    };
                    studentAttendViewList.Add(studentAttendView);
                }
                return studentAttendViewList;
            }
        }
        public static void ChangeAttendenceState(AttendenceViewModel attendenceViewModel)
        {
            using (var context = new FinalSchool())
            {
                var studentAtt = context.Students.FirstOrDefault(x => x.StudentId == attendenceViewModel.StudentSNN);
                var courseAtt = context.Courses.FirstOrDefault(x => x.Name == attendenceViewModel.CourseName);
                var teacher = context.Teachers.FirstOrDefault(x => x.FName == attendenceViewModel.TeacherName);
                var session = new Session
                {
                    Course = courseAtt,
                    CourseId = courseAtt.CourseId,
                    StartDate = DateTime.Now,
                    Teacher = teacher,
                    TeacherId = teacher.TeacherId,

                };
                context.Sessions.Add(session);
                context.SaveChanges();
                var attendence = new Attendence()
                {
                    Student = studentAtt,
                    StudentId = studentAtt.StudentId,
                    IsAttended = attendenceViewModel.IsAttended,
                    Session = session,
                    SessionId = session.SessionId,

                };
                context.Attendences.Add(attendence);
                context.SaveChanges();
            }

        }

        public static void PostListOfAttendenceState(List<AttendenceViewModel> attendenceViewModel)
        {
            using (var context = new FinalSchool())
            {
                var CN = attendenceViewModel[0].CourseName;
                var courseAtt = context.Courses.FirstOrDefault(x => x.Name == CN);
                var te = attendenceViewModel[0].TeacherSNN;
                Teacher teacher = context.Teachers.FirstOrDefault(x => x.TeacherId == te);

                var session = new Session
                {
                    CourseId = courseAtt.CourseId,
                    StartDate = DateTime.Now,
                    TeacherId = teacher.TeacherId,

                };
                context.Sessions.Add(session);
                context.SaveChanges();
                foreach (var item in attendenceViewModel)
                {
                    var attendence = new Attendence()
                    {
                        StudentId = item.StudentSNN,
                        IsAttended = item.IsAttended,
                        SessionId = session.SessionId,
                    };
                    context.Attendences.Add(attendence);
                }
                context.SaveChanges();
            }
        }
    }
}