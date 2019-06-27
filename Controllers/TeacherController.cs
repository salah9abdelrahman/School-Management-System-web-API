using School_managment_system.Models;
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
    public class TeacherController : ApiController
    {

        public IEnumerable<TeacherViewModel> Get()
        {
            return TeacherService.GetAll();
           
        }


        public  TeacherViewModel Get(int id)
        {
            return TeacherService.GetOne(id);
        }




        public void Post(TeacherViewModel teacherModel)
        {
            TeacherService.PostOne(teacherModel);

        }
        public void Put(  TeacherViewModel teacherModel)
        {
            TeacherService.PutOne( teacherModel);
        }

        public void Delete(int id)
        {
            TeacherService.DeleteOne(id);
        }
    }
}
