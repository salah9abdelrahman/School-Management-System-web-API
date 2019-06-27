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
                    classRoomListModel.Add(new ClassRoomViewModel { Name = item.Name, LevelId = item.LevelId });

                }
                return classRoomListModel;
            }
        }


        public static ClassRoomViewModel GetOne(int id)
        {
            using (var context = new FinalSchool())
            {

                var classRoom = context.ClassRooms.Find(id);
                var classRoomModel = new ClassRoomViewModel() { Name = classRoom.Name, LevelId = classRoom.LevelId };
                return classRoomModel;
            }
        }


        public static void PostOne(ClassRoomViewModel classRoomModel)
        {
            using (var context = new FinalSchool())
            {
                var classRoom = new ClassRoom() { Name = classRoomModel.Name, LevelId = classRoomModel.LevelId };
                context.ClassRooms.Add(classRoom);
                context.SaveChanges();

            }
        }

        public static void PutOne(int id, ClassRoomViewModel classRoomModel)
        {
            using (var context = new FinalSchool())
            {
                var classRoom = context.ClassRooms.Find(id);
                classRoom.Name = classRoomModel.Name;
                classRoom.LevelId = classRoomModel.LevelId;

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
    }
}