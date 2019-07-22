using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class TeacherService
    {

        public static IEnumerable<TeacherViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var TeacherModel = new List<TeacherViewModel>();
                foreach (var item in context.Teachers.ToList())
                {
                    var courseTeacher = context.TeacherCourses.Where(x => x.TeacherId == item.TeacherId).ToList();
                    List<int> ids = new List<int>();
                    foreach (var courseId in courseTeacher)
                    {
                        ids.Add(courseId.CourseId);
                    }
                    List<string> courseList = new List<string>();

                    foreach (var id in ids)
                    {
                        var x = context.Courses.FirstOrDefault(ww => ww.CourseId == id).Name;
                        courseList.Add(x);
                    }
                    var teacher = new TeacherViewModel()
                    {

                        FName = item.FName,
                        Age = item.Age,
                        City = item.City,
                        Street = item.Street,
                        LName = item.LName,
                        Email = item.Email,
                        Gender = item.Gender,
                        Password = item.Password,
                        Phone = item.Phone,
                        TeacherSNN = item.TeacherId,
                        CourseName = courseList
                    };
                    TeacherModel.Add(teacher);
                }
                return TeacherModel;
            }
        }
        public static TeacherViewModel GetOne(string id)
        {
            using (var context = new FinalSchool())
            {

                var teacher = context.Teachers.Find(id);
                var courses = (from course in context.Courses
                               join techcourse in context.TeacherCourses
                               on course.CourseId equals techcourse.CourseId
                               join teach in context.Teachers
                               on techcourse.TeacherId equals teach.TeacherId
                               where teach.TeacherId == id
                               select course.Name).ToList();

                var teacherModel = new TeacherViewModel()
                {
                    TeacherSNN = teacher.TeacherId,
                    FName = teacher.FName,
                    Age = teacher.Age,
                    City = teacher.City,
                    Street = teacher.Street,
                    LName = teacher.LName,
                    Email = teacher.Email,
                    Gender = teacher.Gender,
                    Password = teacher.Password,
                    Phone = teacher.Phone,
                    CourseName = courses,
                };
                return teacherModel;
            }
        }

        public static void PutOne(TeacherViewModel teacherModel)
        {
            using (var context = new FinalSchool())
            {
                var id = teacherModel.TeacherSNN;

                foreach (var item in teacherModel.CourseName)
                {
                    var CourseId = context.Courses.FirstOrDefault(w => w.Name == item).CourseId;
                    var teacherCourse = context.TeacherCourses.Find(id);
                    teacherCourse.TeacherId = id;
                    teacherCourse.CourseId = CourseId;
                }
                var teacher = context.Teachers.FirstOrDefault(x => x.TeacherId == teacherModel.TeacherSNN);

                teacher.TeacherId = teacherModel.TeacherSNN;
                teacher.FName = teacherModel.FName;
                teacher.Email = teacherModel.Email;
                teacher.Password = teacherModel.Password;
                teacher.LName = teacherModel.LName;
                teacher.Gender = teacherModel.Gender;
                teacher.Street = teacherModel.Street;
                teacher.City = teacherModel.City;
                teacher.Phone = teacherModel.Phone;
                teacher.Age = teacherModel.Age;

                context.SaveChanges();
            }

        }

        public static void PostOne(TeacherViewModel teacherModel)
        {
            using (var context = new FinalSchool())
            {
                var teacher = new Teacher()
                {
                    TeacherId = teacherModel.TeacherSNN,
                    FName = teacherModel.FName,
                    Age = teacherModel.Age,
                    City = teacherModel.City,
                    Street = teacherModel.Street,
                    LName = teacherModel.LName,
                    Email = teacherModel.Email,
                    Gender = teacherModel.Gender,
                    Password = teacherModel.Password,
                    Phone = teacherModel.Phone,
                };
                context.Teachers.Add(teacher);

                foreach (var item in teacherModel.CourseName)
                {
                    var CourseId = context.Courses.FirstOrDefault(w => w.Name == item).CourseId;
                    var teacherCourse = new TeacherCourse()
                    {
                        TeacherId = teacher.TeacherId,
                        CourseId = CourseId
                    };
                    context.TeacherCourses.Add(teacherCourse);
                }
                context.SaveChanges();
            }
        }

        public static void DeleteOne(string id)
        {
            using (var context = new FinalSchool())
            {
                var teacher = context.Teachers.Find(id);
                context.Teachers.Remove(teacher);
                context.SaveChanges();

            }

        }

    }
}