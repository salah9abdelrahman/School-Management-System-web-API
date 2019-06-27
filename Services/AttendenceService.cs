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
        //public static int Post(AttendenceViewModel attendenceViewModel)
        //{
        //    var Student = new Student()
        //    {
        //        Age = attendenceViewModel.Student.Age,
        //        City = attendenceViewModel.Student.City,
        //        FName = attendenceViewModel.Student.FName,
        //        LName = attendenceViewModel.Student.LName,
        //        JoinDate = attendenceViewModel.Student.JoinDate,
        //        Email = attendenceViewModel.Student.Email,
        //        Street = attendenceViewModel.Student.Street,

        //    }
        //    var attendence = new Attendence()
        //    {
        //        IsAttended = attendenceViewModel.IsAttended,
        //        SessionDate = attendenceViewModel.SessionDate,
        //        Student = ,

        //    }
        //}

            
        //public static AttendenceViewModel Get(int id)
        //{
        //    using(var context = new FinalSchool())
        //    {
        //        var attendenceView = new AttendenceViewModel();
        //        {
                    
        //        }
        //        var studentsClassList = context.Students.Where(x => x.ClassRoomId == id);
        //        var studentViewList = new List<StudentViewModel>();
        //        foreach (var item in studentsClassList)
        //        {
        //            var classView = new ClassRoomViewModel()
        //            {
        //                Name = item.ClassRoom.Name,
        //                LevelId = item.ClassRoom.LevelId
        //            };

        //            var parentView = new ParentViewModel()
        //            {
        //                Email = item.Parent.Email,
        //                FName = item.Parent.FName,
        //                LName = item.Parent.LName,
        //                Password = item.Parent.Password,
        //                SNN = item.Parent.SNN,
        //                ParentId = item.Parent.ParentId
        //            };





        //            var stu = new StudentViewModel()
        //            {
        //                Age = item.Age,
        //                City = item.City,
        //                Email = item.Email,
        //                FName = item.FName,
        //                Gender = item.Gender,
        //                JoinDate = item.JoinDate,
        //                LName = item.LName,
        //                SNN = item.SNN,
        //                Phone = item.Phone,
        //                Street = item.Street,
        //                StudentId = item.StudentId,
        //                Klass = classView,
        //                Parent = parentView,

        //            };

        //            studentViewList.Add(stu);
        //        }
        //        attendenceView.Student = studentViewList;

        //    }
        //}
    }
}