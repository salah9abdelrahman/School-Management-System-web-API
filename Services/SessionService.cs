//using School_managment_system.Models;
//using School_managment_system.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace School_managment_system.Services
//{
//    public class SessionService
//    {
//        public static IEnumerable<SessionViewModel> GetAll()
//        {
//            using (var context = new FinalSchool())
//            {
//                var sessionViewList = new List<SessionViewModel>();
//                foreach (var item in context.Sessions.ToList())
//                {
//                    var sessionView = new SessionViewModel()
//                    {



//                        SessionId = item.SessionId,
//                        CourseName = item.Course.Name,
//                        StartDate = item.StartDate,
//                        //EndDate = item.EndDate,
//                        TeacherFName = item.Teacher.FName,
//                        TeacherLName = item.Teacher.LName

//                    };

//                    sessionViewList.Add(sessionView);
//                }

//                return sessionViewList;
//            }
//        }




//        public static SessionViewModel GetOne(int id)
//        {
//            using(var context =new FinalSchool())
//            {
//                var session= context.Sessions.Find(id);
//                var sessionView = new SessionViewModel()
//                {
//                    CourseName = session.Course.Name,
//                    //EndDate = session.EndDate,
//                    SessionId = session.SessionId,
//                    StartDate = session.StartDate,
//                    TeacherFName = session.Teacher.FName,
//                    TeacherLName = session.Teacher.FName,
//                };

//                return sessionView;

//            }


//        }

//        public static int Create(SessionViewModel sessionViewModel)
//        {
//            using (var context = new FinalSchool())
//            {
//                var teachercourseID = context.TeacherCourses.FirstOrDefault((ww => ww.Course.Name == sessionViewModel.CourseName && ww.Teacher.FName == sessionViewModel.TeacherFName && ww.Teacher.LName == sessionViewModel.TeacherLName)).TeacherCourseId;

//                // context.Teachers
//                var session = new Session()
//                {
//                    StartDate = sessionViewModel.StartDate,
//                    EndDate = sessionViewModel.EndDate,
//                    SessionId = sessionViewModel.SessionId,
//                    TeacherCourseId = teachercourseID,
                    
                    
//                };

//                context.Sessions.Add(session);
//                context.SaveChanges();
//                return session.SessionId;

                
//            }

//        }
        






//    }
//}