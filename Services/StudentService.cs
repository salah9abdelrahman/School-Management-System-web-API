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
                        Password=item.Password,

                        Age = item.Age,
                        City = item.City,
                        Email = item.Email,
                        FName = item.FName,
                        Gender = item.Gender,
                        LName = item.LName,
                        Phone = item.Phone,
                        Street = item.Street,
                        ClassName = item.ClassRoom.Name,
                        StudentSNN = item.StudentId,
                        LevelName = item.ClassRoom.Level.Name,
                        ParentFName = item.Parent.FName,
                        ParentLName = item.Parent.LName,
                        ParentSNN = item.Parent.ParentSNN,
                    };
                    studentViewList.Add(studentView);
                }
                return studentViewList;
            }
        }
        public static StudentViewModel GetOne(string id)
        {
            using (var context = new FinalSchool())
            {
                var student = context.Students.Find(id);
                var studentView = new StudentViewModel()
                {
                    Password=student.Password,
                    Age = student.Age,
                    City = student.City,
                    Email = student.Email,
                    FName = student.FName,
                    Gender = student.Gender,
                    LName = student.LName,
                    Phone = student.Phone,
                    Street = student.Street,
                    StudentSNN = student.StudentId,
                    ClassName = student.ClassRoom.Name,
                    LevelName = student.ClassRoom.Level.Name,
                    ParentFName = student.Parent.FName,
                    ParentLName = student.Parent.LName,
                    ParentSNN = student.Parent.ParentSNN
                };
                return studentView;
            }
        }

        public static string Create(StudentViewModel studentViewModel)
        {
            using (var context = new FinalSchool())
            {
                var classRoomStudent = context.ClassRooms.FirstOrDefault(x => x.Name == studentViewModel.ClassName);
                var stulevel = context.Levels.FirstOrDefault(x => x.Name == studentViewModel.LevelName);
                var studentParent = new Parent()
                {
                    FName = studentViewModel.ParentFName,
                    LName = studentViewModel.ParentLName,
                    ParentSNN = studentViewModel.ParentSNN,
                };
                var student = new Student()
                {
                    Age = studentViewModel.Age,
                    City = studentViewModel.City,
                    Email = studentViewModel.Email,
                    FName = studentViewModel.FName,
                    Gender = studentViewModel.Gender,
                    LName = studentViewModel.LName,
                    Street = studentViewModel.Street,
                    StudentId = studentViewModel.StudentSNN,
                    Phone = studentViewModel.Phone,
                    Parent = studentParent,
                    ClassRoom = classRoomStudent,
                    Password = studentViewModel.Password
                };
                student.ClassRoom.Level = stulevel;
                context.Students.Add(student);
                context.SaveChanges();
                return student.StudentId;
            }
        }


        public static string Edit(StudentViewModel studentViewModel)
        {
            using (var context = new FinalSchool())
            {
                var classroom = context.ClassRooms.FirstOrDefault(x => x.Name == studentViewModel.ClassName);
                var level = context.Levels.FirstOrDefault(x => x.Name == studentViewModel.LevelName);
                var student = context.Students.FirstOrDefault(ww => ww.StudentId == studentViewModel.StudentSNN);
                student.Age = studentViewModel.Age;
                student.City = studentViewModel.City;
                student.Email = studentViewModel.Email;
                student.FName = studentViewModel.FName;
                student.Gender = studentViewModel.Gender;
                student.LName = studentViewModel.LName;
                student.Street = studentViewModel.Street;
                student.StudentId = studentViewModel.StudentSNN;
                student.Phone = studentViewModel.Phone;
                student.ClassRoom = classroom;
                student.ClassRoom.Level = level;
                student.Password = studentViewModel.Password;
                var parent = new Parent()
                {
                    FName = studentViewModel.ParentFName,
                    LName = studentViewModel.LName,
                };

                context.Parents.Add(parent);
                context.SaveChanges();
                student.Parent = parent;
                context.SaveChanges();
                return student.StudentId;
            }
        }
        public static void Delete(string id)
        {
            using (var context = new FinalSchool())
            {
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
            }
        }

        /////
        ///Additions
         /*to get Students in a specific class in a specific course*/
        public static IEnumerable<StudentViewModel> GetStudentsToSepcificClass(string className)
        {
            using (var context = new FinalSchool())
            {
                var studentsViewList = new List<StudentViewModel>();
                var studentsClass = context.Students.Where(x => x.ClassRoom.Name == className).ToList();

                foreach (var item in studentsClass)
                {
                    var studentView = new StudentViewModel
                    {
                        Age = item.Age,
                        City = item.City,
                        Email = item.Email,
                        FName = item.FName,
                        Gender = item.Gender,
                        LName = item.LName,
                        Phone = item.Phone,
                        Street = item.Street,
                        StudentSNN = item.StudentId,
                        ClassName = item.ClassRoom.Name,
                        LevelName = item.ClassRoom.Level.Name,
                        ParentFName = item.Parent.FName,
                        ParentLName = item.Parent.LName,
                        Password = item.Password,
                        ParentSNN = item.Parent.ParentSNN,
                    };
                    studentsViewList.Add(studentView);
                }
                return studentsViewList;
            }

        }
    }
}