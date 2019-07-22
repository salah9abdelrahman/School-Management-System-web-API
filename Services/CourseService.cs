
using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class CourseService
    {
        public static IEnumerable<CourseViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var courseListModel = new List<CourseViewModel>();
                foreach (var item in context.Courses.ToList())
                {
                    CourseViewModel v = new CourseViewModel();
                    v.Name = item.Name;
                    var level=context.Levels.FirstOrDefault(ww=>ww.LevelId==item.LevelId);
                    v.LevelName = level.Name;
                    v.CourseId = item.CourseId;
                    courseListModel.Add(v);
                }
                return courseListModel;
            }
        }
        public static CourseViewModel GetOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var course = context.Courses.Find(id);
                var level = context.Levels.FirstOrDefault(x => x.LevelId == course.LevelId);
                var courseView = new CourseViewModel()
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    LevelName = level.Name,
                 };
                return courseView;
            }
        }
        public static int PostOne(CourseViewModel courseViewModel)
        {
            using (var context = new FinalSchool())
            {
                var level = context.Levels.FirstOrDefault(x => x.Name == courseViewModel.LevelName);
                var course = new Course()
                {
                    Name = courseViewModel.Name,
                    LevelId = level.LevelId
                };

                context.Courses.Add(course);
                context.SaveChanges();
                return course.CourseId;
            }
        }
        public static void PutOne(CourseViewModel courseViewModel)
        {
            using (var context = new FinalSchool())
            {
                var course = context.Courses.FirstOrDefault(w=>w.CourseId== courseViewModel.CourseId);
                var level = context.Levels.FirstOrDefault(x => x.Name == courseViewModel.LevelName);
                course.Name = courseViewModel.Name;
                course.LevelId = level.LevelId;
                context.SaveChanges();
            }

        }
        public static int DeleteOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var course = context.Courses.Find(id);
                if (course != null)
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }

                return course.CourseId;
            }
        }

        public static List<CourseViewModel> GetCoursesToTeacher(string snn)
        {
            using (var context = new FinalSchool())
            {
                var CourseViewModelList = new List<CourseViewModel>();

                var coursesNeww = (from teacher in context.Teachers
                                   join tc in context.TeacherCourses
                                   on teacher.TeacherId equals tc.TeacherId
                                   where teacher.TeacherId == snn
                                   join course in context.Courses
                                   on tc.CourseId equals course.CourseId
                                   select course).ToList();

                foreach (var course in coursesNeww)
                {
                    var courseView = new CourseViewModel()
                    {
                        CourseId = course.CourseId,
                        LevelName = course.Level.Name,
                        Name = course.Name
                    };
                    CourseViewModelList.Add(courseView);
                }
                return CourseViewModelList;
            }
        }
    }
}