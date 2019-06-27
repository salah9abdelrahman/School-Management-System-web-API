using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class StudentService
    {
        public static IEnumerable<StudentViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var studentViewList = new List<StudentViewModel>();
                foreach (var item in context.Students.ToList())
                {
                    var studentView = new StudentViewModel()
                    {
                        Age = item.Age,
                        City = item.City,
                        Email = item.Email,
                        FName = item.FName,
                        Gender = item.Gender,
                        JoinDate = item.JoinDate,
                        LName = item.LName,
                        SNN=item.SNN,
                        Phone=item.Phone,
                        Street=item.Street,
                        StudentId=item.StudentId,
                        ClassName = item.ClassRoom.Name,
                        LevelName = item.ClassRoom.Level.Name,
                        ParentFName = item.Parent.FName ,
                        ParentLName = item.Parent.LName,
                       
                    };

                    studentViewList.Add(studentView);

                }
                return studentViewList;
            }
        }
        public static StudentViewModel GetOne(int id)
        {
            using(var context = new FinalSchool())
            {
                var student = context.Students.Find(id);
                var studentView = new StudentViewModel()
                {
                    Age = student.Age,
                    City = student.City,
                    Email = student.Email,
                    FName = student.FName,
                    Gender = student.Gender,
                    JoinDate = student.JoinDate,
                    LName = student.LName,
                    SNN = student.SNN,
                    Phone = student.Phone,
                    Street = student.Street,
                    StudentId = student.StudentId,
                    ClassName = student.ClassRoom.Name,
                    LevelName = student.ClassRoom.Level.Name,
                    ParentFName = student.Parent.FName,
                    ParentLName = student.Parent.LName,                 
                };
                return studentView;
            }
        }

        public static int Create(StudentViewModel studentViewModel)
        {
            using(var context = new FinalSchool())
            {
                var classRoomStudent = context.ClassRooms.FirstOrDefault(x => x.Name == studentViewModel.ClassName);                
                var studentParent = new Parent()
                {
                    FName = studentViewModel.ParentFName,
                    LName = studentViewModel.ParentLName,
                    //Email = studentViewModel.
                    SNN = studentViewModel.ParentSNN
                    //Password = studentViewModel.pass 

                };
                var student = new Student()
                {
                    Age = studentViewModel.Age,
                    City = studentViewModel.City,
                    Email = studentViewModel.Email,
                    FName = studentViewModel.FName,
                    Gender = studentViewModel.Gender,
                    JoinDate = studentViewModel.JoinDate,
                    LName = studentViewModel.LName,
                    SNN = studentViewModel.SNN,
                    Street = studentViewModel.Street,
                    StudentId = studentViewModel.StudentId,
                    Phone = studentViewModel.Phone,                   
                    Parent = studentParent,                   
                    ClassRoom = classRoomStudent,                 
                };
                context.Students.Add(student);
                context.SaveChanges();
                return student.StudentId;
            }
        }


        public static int Edit(StudentViewModel studentViewModel)
        {
            using(var context=new FinalSchool())
            {
               var classroom = context.ClassRooms.FirstOrDefault(x => x.Name == studentViewModel.ClassName);
                var student = context.Students.FirstOrDefault(ww => ww.StudentId == studentViewModel.StudentId);
                student.Age = studentViewModel.Age;
                student.City = studentViewModel.City;
                student.Email = studentViewModel.Email;
                student.FName = studentViewModel.FName;
                student.Gender = studentViewModel.Gender;
                student.JoinDate = studentViewModel.JoinDate;
                student.LName = studentViewModel.LName;
                student.SNN = studentViewModel.SNN;
                student.Street = studentViewModel.Street;
                student.StudentId = studentViewModel.StudentId;
                student.Phone = studentViewModel.Phone;
                var parent = new Parent()
                {
                   FName = studentViewModel.ParentFName,
                   LName = studentViewModel.LName,
                   SNN = studentViewModel.SNN,            
                };
                context.Parents.Add(parent);
                context.SaveChanges();
                student.Parent = parent;
                context.SaveChanges();
                return parent.ParentId;
            }
        }
        public static void Delete(int id)
        {
            using(var context = new FinalSchool())
            {
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
            }
        }
    }
}