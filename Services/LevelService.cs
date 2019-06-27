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
            using(var context=new FinalSchool())
            {
                var levelListModel = new List<LevelViewModel>();
                foreach (var item in context.Levels.ToList())
                {
                    levelListModel.Add(new LevelViewModel { Name = item.Name });

                }
                return levelListModel;
            }
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


        public static void PostOne(LevelViewModel levelModel)
        {
            using (var context = new FinalSchool())
            {
                var level = new Level() { Name = levelModel.Name };
                context.Levels.Add(level);
                context.SaveChanges();

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



    }
}