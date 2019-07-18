using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class LevelService
    {
        public static IEnumerable<LevelViewModel> GetAll()
        {
            var levelListModel = new List<LevelViewModel>();

            using (var context = new FinalSchool())
            {
                foreach (var item in context.Levels.ToList())
                {
                    levelListModel.Add(new LevelViewModel { Name = item.Name, LevelId = item.LevelId });
                }
            }
            return levelListModel;

        }


        public static LevelViewModel GetOne(int id)
        {
            using (var context = new FinalSchool())
            {

                var level = context.Levels.Find(id);
                var levelModel = new LevelViewModel() { Name = level.Name };
                return levelModel;
            }
        }


        public static int PostOne(LevelViewModel levelModel)
        {
            using (var context = new FinalSchool())
            {
                var level = new Level() { Name = levelModel.Name, LevelId = levelModel.LevelId };
                context.Levels.Add(level);
                context.SaveChanges();
                return level.LevelId;

            }
        }

        public static void PutOne(int id, LevelViewModel levelModel)
        {
            using (var context = new FinalSchool())
            {
                var level = context.Levels.Find(id);
                level.Name = levelModel.Name;

                context.SaveChanges();
            }

        }


        public static void DeleteOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var level = context.Levels.Find(id);
                context.Levels.Remove(level);
                context.SaveChanges();

            }
        }


        public static int GetLevelByName(string levelName)
        {
            using (var context = new FinalSchool())
            {
                var level = context.Levels.FirstOrDefault(x => x.Name == levelName);
                var levelview = new LevelViewModel()
                {
                    Name = level.Name,
                    LevelId = level.LevelId,
                };
                return levelview.LevelId;
            }
        }

        public static IEnumerable<LevelViewModel> GetLevelsToTeacher(string teacherSnn)
        {
            using (var context = new FinalSchool())
            {
                var LevelViewModelList = new List<LevelViewModel>();
                var teacherCourses = context.TeacherCourses.Where(x => x.TeacherId == teacherSnn).ToList();
                List<int> coursesId = new List<int>();
                foreach (var cid in teacherCourses)
                {
                    coursesId.Add(cid.CourseId);
                }
                //var levels = context.Courses.Where(x=>x.LevelId == )
                var courses = new List<Course>();
                foreach (var courseID in coursesId)
                {
                    courses.AddRange(context.Courses.Where(x => x.CourseId == courseID).ToList());
                }
                var levelsId = new List<int>();
                foreach (var lvlId in courses)
                {
                    levelsId.Add(lvlId.LevelId);
                }

                // var levels =context.Levels.Where(x=>x.LevelId = )
                var levels = new List<Level>();
                foreach (var levelid in levelsId)
                {
                    levels.AddRange(context.Levels.Where(x => x.LevelId == levelid));
                }
                foreach (var level in levels)
                {
                    var levelView = new LevelViewModel()
                    {
                        Name = level.Name,
                        LevelId = level.LevelId,
                    };
                    if (LevelViewModelList.FirstOrDefault(x=>x.LevelId == levelView.LevelId)==null)
                    {
                        LevelViewModelList.Add(levelView);

                    }
                }
                return LevelViewModelList;
            }
        }



    }
}