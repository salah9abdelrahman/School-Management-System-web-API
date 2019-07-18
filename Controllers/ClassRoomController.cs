using School_managment_system.Services;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_managment_system.Controllers
{
    public class ClassRoomController : ApiController
    {

        public IEnumerable<ClassRoomViewModel> Get()
        {
            return ClassRoomService.GetAll();

        }


        public ClassRoomViewModel Get(int id)
        {
            return ClassRoomService.GetOne(id);
        }




        public int Post(ClassRoomViewModel classRoomViewModel)
        {
            return ClassRoomService.PostOne(classRoomViewModel);

        }
        public void Put(ClassRoomViewModel classRoomViewModel)
        {
            ClassRoomService.PutOne(classRoomViewModel);
        }

        public void Delete(int id)
        {
            ClassRoomService.DeleteOne(id);
        }

        public IEnumerable<ClassRoomViewModel> GetClassesToLevel(string levelName)
        {
            return ClassRoomService.GetClassesToLevel(levelName);
        }
    }
}
