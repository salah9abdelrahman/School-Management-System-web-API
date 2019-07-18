using School_managment_system.Models;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_managment_system.Services
{
    public class ClassRoomService
    {


        public static IEnumerable<ClassRoomViewModel> GetAll()
        {
            using (var context = new FinalSchool())
            {
                var classRoomListModel = new List<ClassRoomViewModel>();
                foreach (var item in context.ClassRooms.ToList())
                {
                    classRoomListModel.Add(new ClassRoomViewModel {
                        Name = item.Name,
                       // LevelId = item.LevelId,
                        ClassId =item.ClassRoomId,
                        LevelName = item.Level.Name,
                    });
                }
                return classRoomListModel;
            }
        }


        public static ClassRoomViewModel GetOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var classRoom = context.ClassRooms.Find(id);
                var classRoomModel = new ClassRoomViewModel() {
                    Name = classRoom.Name,
                 //  LevelId = classRoom.LevelId,
                    ClassId = classRoom.ClassRoomId,
                    LevelName = classRoom.Level.Name,
                };
                return classRoomModel;
            }
        }


        public static int PostOne(ClassRoomViewModel classRoomModel)
        {
            using (var context = new FinalSchool())
            {
                var levelId = context.Levels.FirstOrDefault(x => x.Name == classRoomModel.LevelName).LevelId;
                var classRoom = new ClassRoom() {
                    Name = classRoomModel.Name,
                    LevelId = levelId,
                    ClassRoomId = classRoomModel.ClassId,
                    
                };
                context.ClassRooms.Add(classRoom);
                context.SaveChanges();
                return classRoom.ClassRoomId;
            }
        }

        public static void PutOne(ClassRoomViewModel classRoomModel)
        {
            using (var context = new FinalSchool())
            {
                var classRoom = context.ClassRooms.Find(classRoomModel.ClassId);
                classRoom.Name = classRoomModel.Name;
               // classRoom.LevelId = classRoomModel.LevelId;
                classRoom.ClassRoomId = classRoomModel.ClassId;
                classRoom.Level.Name = classRoomModel.LevelName;
                context.SaveChanges();
            }
        }

        public static void DeleteOne(int id)
        {
            using (var context = new FinalSchool())
            {
                var classRoom = context.ClassRooms.Find(id);
                context.ClassRooms.Remove(classRoom);
                context.SaveChanges();
            }
        }

        public static IEnumerable<ClassRoomViewModel> GetClassesToLevel(string levelName)
        {
            using (var context = new FinalSchool())
            {
                var levelId = context.Levels.FirstOrDefault(x => x.Name == levelName).LevelId;
                var classrooms = context.ClassRooms.Where(x => x.LevelId == levelId).ToList();
                var coursesViewList = new List<ClassRoomViewModel>();
                foreach (var klass in classrooms)
                {
                    var coureView = new ClassRoomViewModel()
                    {
                        ClassId = klass.ClassRoomId,
                        Name = klass.Name,
                        LevelName = klass.Level.Name
                    };
                    coursesViewList.Add(coureView);
                }
                return coursesViewList;
            }
        }
    }
}